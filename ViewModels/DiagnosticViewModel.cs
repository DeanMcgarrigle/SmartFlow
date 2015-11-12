using System.Collections.Generic;

namespace SmartFlow.ViewModels
{
    public class DiagnosticViewModel
    {
        public List<DiagnosticResult> Results { get; set; }
        public List<AccessPointDiagnosticResult> AccessPoints { get; set; }

        public DiagnosticViewModel()
        {
            Results = new List<DiagnosticResult>();
            AccessPoints = new List<AccessPointDiagnosticResult>();
        }
    }
}