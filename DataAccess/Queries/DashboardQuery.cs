using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using SmartFlow.Entity;
using SmartFlow.ViewModels;

namespace SmartFlow.DataAccess.Queries
{
    public class DashboardQuery
    {
        private int SeenPercentage = 90;

        public IEnumerable<ReportListResult> Floors { get; private set; }

        public DashboardQuery(SmartFlowContext context, DateTime fromDate, DateTime toDate)
        {
            var aps = context.AccessPointConfigs.Where(x => x.IsActive).ToList();
            var config = context.DashboardConfigs.FirstOrDefault() ?? new DashboardConfig
            {
                MaximumUnc = 30,
                MinimumAccessPoints = 1,
                MinimumObservations = 5
            };

            var query = context.FloorLocations
                .Include(x => x.Location.Observation)
                .Where(z => z.Location.Observation.SeenTime >= fromDate && z.Location.Observation.SeenTime <= toDate)
                .Where(x => x.Location.Unc <= config.MaximumUnc)
                .AsNoTracking()
                .ToList()
                .GroupBy(x => x.Name)
                .Where(x => x.GroupBy(z => z.ApMac).Count() >= config.MinimumAccessPoints)
                .Select(x => new { Floor = x.Key, Clients = x.GroupBy(y => y.Location.Observation.ClientMac).Where(z => z.Count() >= config.MinimumObservations) })
                ;

            Floors = new List<ReportListResult>(query.Select(x => new ReportListResult
                {
                    Floor = x.Floor,
                    Observations = x.Clients.Sum(y => y.Count()),
                    TotalClients = x.Clients.Count(),
                    DwellTime = TimeSpan.FromTicks(Convert.ToInt64(x.Clients.Average(q => (q.Max(z => z.Location.Observation.SeenTime) - q.Min(z => z.Location.Observation.SeenTime)).Ticks))),
                    AccessPoints = aps.Where(y => y.Name == x.Floor).Select(y => new AccessPointDiagnosticResult
                    {
                        ApMac = y.ApMac,
                        DisplayName = y.DisplayName,
                        SeenTime = x.Clients.SelectMany(q => q).Any(z => z.ApMac == y.ApMac) ? x.Clients.SelectMany(q => q).Where(z => z.ApMac == y.ApMac).Max(z => z.Location.Observation.SeenTime) : DateTime.MinValue
                    }).OrderBy(y => y.DisplayName).ToList()
                }));
        }
    }
}