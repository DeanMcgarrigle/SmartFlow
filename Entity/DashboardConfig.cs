using System;

namespace SmartFlow.Entity
{
    public class DashboardConfig
    {
        public Guid RecordId { get; set; }
        public int MinimumObservations { get; set; }
        public int MaximumUnc { get; set; }
        public int MinimumAccessPoints { get; set; }
    }
}