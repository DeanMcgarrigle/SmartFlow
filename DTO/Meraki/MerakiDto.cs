using System;
using System.Text;

namespace SmartFlow.DTO.Meraki
{
    public class MerakiDto
    {
        public string Version { get; set; }
        public string Secret { get; set; }
        public DataDto Data { get; set; }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendFormat("Version: {0} {1}", Version, Environment.NewLine);
            sb.AppendFormat("{0} {1}", Data.ToString(), Environment.NewLine);
            
            sb.AppendFormat("{0}", Environment.NewLine);
            sb.AppendFormat("{0}", Environment.NewLine);

            return sb.ToString();
        }
    }
}