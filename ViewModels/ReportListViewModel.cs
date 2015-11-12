using System;
using System.Collections.Generic;
using System.Linq;

namespace SmartFlow.ViewModels
{
    public class ReportListViewModel
    {
        public string FromDate { get; set; }
        public string ToDate { get; set; }
        public int TotalClients { get { return Floors.Sum(x => x.TotalClients); } }
        public string DwellTime { get { return Floors.Any() ? TimeSpan.FromTicks(Convert.ToInt64(Floors.Average(x => x.DwellTime.Ticks))).ToString(@"hh\:mm\:ss") : "00:00:00"; } }
        public int ActiveFloors { get { return Floors.Count; } }
        public List<ReportListResult> Floors { get; set; }

        public ReportListViewModel()
        {
            FromDate = DateTime.Now.Date.ToString();
            ToDate = DateTime.Now.ToString();
            Floors = new List<ReportListResult>();
        }
    }
}