using System;

namespace SmartFlow.ViewModels
{
    public class AccessPointDiagnosticResult
    {
        public string ApMac { get; set; }
        public DateTime SeenTime { get; set; }
        public string Name { get; set; }
        public string DisplayName { get; set; }
        public bool ShowAlert { get { return (DateTime.Now - SeenTime).TotalMinutes >= 3; } }
    }
}