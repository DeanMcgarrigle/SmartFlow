using System;

namespace SmartFlow.ViewModels
{
    public class SnapshotListResult
    {
        public string ClientMac { get; set; }
        public decimal X { get; set; }
        public decimal Y { get; set; }
        public DateTime SeenTime { get; set; }
        public decimal Unc { get; set; }
        public int Rssi { get; set; }
        public string ApMac { get; set; }
        public Guid RecordId { get; set; }
    }
}