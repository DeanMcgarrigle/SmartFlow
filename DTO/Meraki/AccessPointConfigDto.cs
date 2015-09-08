using System.Collections.Generic;
using Nancy.Validation;

namespace SmartFlow.DTO.Meraki
{
    public class AccessPointConfigDto
    {
        public string Name { get; set; }
        public string ApMac { get; set; }
        public string DisplayName { get; set; }
        public decimal X { get; set; }
        public decimal Y { get; set; }
        public bool IsActive { get; set; }
        public IDictionary<string, IList<ModelValidationError>> Errors { get; set; }

        public AccessPointConfigDto()
        {
            Errors = new Dictionary<string, IList<ModelValidationError>>();
        }
    }
}