using System;

namespace SmartFlow.Entity
{
    public class Observation
    {
        public Guid RecordId { get; set; }
        public string ClientMac { get; set; }
        public string Ipv4 { get; set; }
        public string Ipv6 { get; set; }
        public DateTime SeenTime { get; set; }
        public int SeenEpoch { get; set; }
        public string Ssid { get; set; }
        public int Rssi { get; set; }
        public string Manufacturer { get; set; }
        public string Os { get; set; }

        public string ApMac { get; set; }

        public virtual Location Location { get; set; }
    }
}