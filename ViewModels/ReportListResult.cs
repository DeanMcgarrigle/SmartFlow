using System;
using System.Collections.Generic;

namespace SmartFlow.ViewModels
{
    public class ReportListResult
    {
        public string Floor { get; set; }
        public int Observations { get; set; }
        public List<AccessPointDiagnosticResult> AccessPoints { get; set; }
        public int TotalClients { get; set; }
        public TimeSpan DwellTime { get; set; }
        public string DwellTimeFmt { get { return DwellTime.ToString(@"hh\:mm\:ss"); } }

        public ReportListResult()
        {
            AccessPoints = new List<AccessPointDiagnosticResult>();
        }
    }
}