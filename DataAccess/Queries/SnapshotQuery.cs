using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using SmartFlow.ViewModels;

namespace SmartFlow.DataAccess.Queries
{
    public class SnapshotQuery
    {
        public IEnumerable<SnapshotListResult> Results { get; private set; }

        public SnapshotQuery(SmartFlowContext context, DateTime fromDate, DateTime toDate, string floor)
        {
            Results = new List<SnapshotListResult>(context.Observations
                .AsNoTracking()
                .Include(x => x.Location.FloorLocations)
                .Where(x => x.SeenTime >= fromDate && x.SeenTime <= toDate)
                .Where(x => x.Location.FloorLocations.Any(y => y.Name == floor))
                .Select(x => new
                {
                    x.ClientMac,
                    x.Location.FloorLocations.FirstOrDefault(y => y.Name == floor).X,
                    x.Location.FloorLocations.FirstOrDefault(y => y.Name == floor).Y,
                    x.SeenTime,
                    x.Location.Unc,
                    x.Rssi,
                    x.ApMac,
                    x.RecordId
                })
                .ToList()
                .GroupBy(x => x.ClientMac)
                .Select(x => x.OrderByDescending(y => y.SeenTime).FirstOrDefault())
                .Select(x => new SnapshotListResult
                {
                    ClientMac = x.ClientMac,
                    X = x.X,
                    Y = x.Y,
                    SeenTime = x.SeenTime,
                    Unc = x.Unc,
                    Rssi = x.Rssi,
                    ApMac = x.ApMac,
                    RecordId = x.RecordId,
                })
                .OrderBy(x => x.SeenTime));
        }
    }
}