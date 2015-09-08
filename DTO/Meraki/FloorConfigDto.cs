using System.Collections.Generic;
using Nancy.Validation;

namespace SmartFlow.DTO.Meraki
{
    public class FloorConfigDto
    {
        public string Name { get; set; }
        public decimal X { get; set; }
        public decimal Y { get; set; }
        public IDictionary<string, IList<ModelValidationError>> Errors { get; set; }

        public FloorConfigDto()
        {
            Errors = new Dictionary<string, IList<ModelValidationError>>();
        }
    }
}