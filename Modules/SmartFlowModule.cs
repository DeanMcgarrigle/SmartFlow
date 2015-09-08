using System;
using System.IO;
using System.Linq;
using Nancy;
using Nancy.Json;
using Nancy.ModelBinding;
using SmartFlow.DataAccess;
using SmartFlow.DataAccess.Queries;
using SmartFlow.Helpers;
using SmartFlow.ViewModels;

namespace SmartFlow.Modules
{
    public class SmartFlowModule : NancyModule
    {
        public SmartFlowModule(SmartFlowContext context)
            : base("/smartflow")
        {
            //this.RequiresAuthentication();
            JsonSettings.MaxJsonLength = Int32.MaxValue;

            Get["/admin"] = _ =>
            {
                return Negotiate.WithView("SmartFlow/Admin");
            };

            Get["/"] = _ =>
            {
                return View["SmartFlow/List"];
            };

            Get["/snapshot"] = _ =>
            {
                var model = this.Bind<SnapshotViewModel>();
                model.Floors.AddRange(context.Floors.Select(x => x.Name).Distinct());
                model.Floor = !string.IsNullOrEmpty(model.Floor) ? model.Floor : context.Floors.First().Name;
                var floorConfig = context.FloorConfigs.FirstOrDefault(x => x.Name == model.Floor);
                if (floorConfig != null)
                {
                    model.X = floorConfig.X;
                    model.Y = floorConfig.Y;
                }
                model.ImagePath = string.Format(@"/images/{0}.png", model.Floor);
                try
                {
                    var chartSize = ImageHelper.GetChartDimensions(model.Floor, model.ChartWidth, model.ChartHeight);
                    model.ChartWidth = chartSize.Width;
                    model.ChartHeight = chartSize.Height;
                }
                catch (FileNotFoundException ex)
                {
                    model.ImagePath = string.Empty;
                }

                var beginTime = DateTime.Parse(model.SelectedDate).AddMinutes(-1);
                var endTime = DateTime.Parse(model.SelectedDate).AddMinutes(1);
                var query = new SnapshotQuery(context, beginTime, endTime, model.Floor);
                model.Results.AddRange(query.Results);

                return Negotiate.WithModel(model);
            };

            Get["/{clientMac}/details"] = _ =>
            {
                var model = this.Bind<ReportDetailsViewModel>();
                //if (!string.IsNullOrEmpty(model.Floor))
                //{
                //    model.ImagePath = string.Format(@"/images/{0}.png", model.Floor);
                //    var floorConfig = context.FloorConfigs.FirstOrDefault(x => x.Name == model.Floor);
                //    if (floorConfig != null)
                //    {
                //        model.X = floorConfig.X;
                //        model.Y = floorConfig.Y;
                //    }
                //    model.AccessPoints = context.AccessPointConfigs.Where(x => x.Name == model.Floor).Where(x => x.IsActive).OrderBy(x => x.DisplayName).ToList();

                //    try
                //    {
                //        var chartSize = ImageHelper.GetChartDimensions(model.Floor, model.ChartWidth, model.ChartHeight);
                //        model.ChartWidth = chartSize.Width;
                //        model.ChartHeight = chartSize.Height;
                //    }
                //    catch (FileNotFoundException ex)
                //    {
                //        model.ImagePath = string.Empty;
                //    }

                //    var beginTime = DateTime.Parse(model.FromDate);
                //    var endTime = DateTime.Parse(model.ToDate);
                //    var results =
                //        context.Observations
                //            .AsNoTracking()
                //            .Include(x => x.Location.FloorLocations)
                //            .Where(x => x.ClientMac == model.ClientMac)
                //            .Where(x => x.Location.FloorLocations.Any(y => y.Name == model.Floor))
                //            .Where(x => x.SeenTime >= beginTime && x.SeenTime <= endTime)
                //            .Where(x => x.Rssi >= model.MinimumRssi)
                //            .Where(x => x.Location.Unc <= model.MaximumUnc)
                //            .Select(x => new ReportDetailsResult
                //            {
                //                X = x.Location.FloorLocations.FirstOrDefault(y => y.Name == model.Floor).X,
                //                Y = x.Location.FloorLocations.FirstOrDefault(y => y.Name == model.Floor).Y,
                //                SeenTime = x.SeenTime,
                //                Unc = x.Location.Unc,
                //                Rssi = x.Rssi,
                //                ApMac =
                //                    context.AccessPointConfigs.FirstOrDefault(
                //                        y => y.ApMac == x.ApMac && y.Name == model.Floor) != null
                //                        ? context.AccessPointConfigs.FirstOrDefault(
                //                            y => y.ApMac == x.ApMac && y.Name == model.Floor).DisplayName
                //                        : x.ApMac,
                //                RecordId = x.RecordId,
                //                Name = model.Floor
                //            })
                //            .OrderBy(y => y.SeenTime)
                //            .ThenBy(x => x.ApMac);

                //    model.Results.AddRange(results);
                //}

                return Negotiate.WithView("SmartFlow/Details").WithModel(model);
            };
        }
    }
}