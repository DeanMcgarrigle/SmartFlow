using System;
using System.Linq;
using FileLogging4Net;
using Nancy;
using Nancy.ModelBinding;
using SmartFlow.DataAccess;
using SmartFlow.DTO.Meraki;
using SmartFlow.Entity;
using SmartFlow.Extensions;
using SmartFlow.Properties;

namespace SmartFlow.Modules
{
    public class MerakiModule : NancyModule
    {
        public MerakiModule(TextFileLogger logger, SmartFlowContext context)
            : base("/meraki")
        {
            // Meraki will use this to validate we are the correct host
            Get["/"] = _ => Settings.Default.Validator;

            Post["/"] = _ =>
            {
                var req = this.Bind<MerakiDto>();

                // secret didnt match, return FORBIDDEN
                if (req.Secret != Settings.Default.Secret) return 403;

                // log to file (will log to database once its all working etc..)
                logger.Write(req.ToString(), Enums.LogLevel.Information);

                var floors = req.Data.ApFloors.Select(x => x.ToFloorEntity(req.Data.ApMac));

                foreach (var floor in floors)
                {
                    if (context.Floors.Any(x => x.ApMac == floor.ApMac && x.Name == floor.Name))
                    {
                        context.Floors.Attach(floor);
                    }
                    else
                    {
                        context.Floors.Add(floor);
                    }
                }

                var thisTime = DateTime.Now;
                var isDaylight = TimeZoneInfo.Local.IsDaylightSavingTime(thisTime);

                var observations = req.Data.Observations.Select(y => new Observation
                {
                    ApMac = req.Data.ApMac,
                    ClientMac = y.ClientMac,
                    Ipv4 = y.Ipv4,
                    Ipv6 = y.Ipv6,
                    Manufacturer = y.Manufacturer,
                    Os = y.Os,
                    Rssi = y.Rssi,
                    SeenTime = isDaylight ? y.SeenTime.AddHours(1) : y.SeenTime,
                    SeenEpoch = y.SeenEpoch,
                    Location = y.Location != null ? y.Location.ToLocationEntity(req.Data) : null
                });

                context.Observations.AddRange(observations);

                // return CREATED
                return 201;
            };
        }
    }
}