using System;
using System.Collections.Generic;
using System.Text;

namespace SmartFlow.DTO.Meraki
{
    public class DataDto
    {
        public string ApMac { get; set; }
        public ICollection<string> ApFloors { get; set; }
        public ICollection<ObservationDto> Observations { get; set; }

        public DataDto()
        {
            Observations = new List<ObservationDto>();
            ApFloors = new List<string>();
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendFormat("ApMac: {0} {1}", ApMac, Environment.NewLine);
            sb.AppendFormat("ApFloors: {0} {1}", string.Join(", ", ApFloors), Environment.NewLine);
            sb.AppendFormat("Observations: {0}", Environment.NewLine);
            foreach (var observation in Observations)
            {
                sb.AppendFormat("\t {0} {1}", observation.ToString(), Environment.NewLine);
            }

            return sb.ToString();
        }
    }
}