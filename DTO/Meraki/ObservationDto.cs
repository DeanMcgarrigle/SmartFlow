using System;
using System.Text;

namespace SmartFlow.DTO.Meraki
{
    public class ObservationDto
    {
        public string ClientMac { get; set; }
        public string Ipv4 { get; set; }
        public string Ipv6 { get; set; }
        public DateTime SeenTime { get; set; }
        public int SeenEpoch { get; set; }
        public string Ssid { get; set; }
        public int Rssi { get; set; }
        public string Manufacturer { get; set; }
        public string Os { get; set; }
        public LocationDto Location { get; set; }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendFormat(
                "ClientMac: {0}, Ipv4: {1}, Ipv6: {2}, SeenTime: {3}, SeenEpoch: {4}, Ssid: {5}, Rssi: {6}, Manufacturer: {7}, Os: {8} {9}",
                ClientMac, Ipv4, Ipv6, SeenTime, SeenEpoch, Ssid, Rssi, Manufacturer, Os, Environment.NewLine);
            if (Location != null)
            {
                sb.AppendFormat("\t\t Location: {0} {1}", Location.ToString(), Environment.NewLine);
            }
            else
            {
                sb.AppendFormat("\t\t Location: NULL {0}", Environment.NewLine);
            }

            return sb.ToString();
        }
    }
}