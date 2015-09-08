using System;
using System.Collections.Generic;
using System.Text;

namespace SmartFlow.DTO.Meraki
{
    public class LocationDto
    {
        public decimal Lat { get; set; }
        public decimal Lng { get; set; }
        public decimal Unc { get; set; }
        public IList<decimal> X { get; set; }
        public IList<decimal> Y { get; set; }

        public LocationDto()
        {
            X = new List<decimal>();
            Y = new List<decimal>();
        }

        public override string ToString()
        {
            var sb = new StringBuilder();

            sb.AppendFormat("Lat: {0}, Lng: {1}, Unc: {2} {3}", Lat, Lng, Unc, Environment.NewLine);
            sb.AppendFormat("X: {0}, Y: {1} {2}", string.Join(", ", X), string.Join(", ", Y), Environment.NewLine);

            return sb.ToString();
        }
    }
}