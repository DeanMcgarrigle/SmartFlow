using System.Collections.Generic;
using Nancy.Validation;

namespace SmartFlow.ViewModels
{
    public class ValidateViewModel
    {
        public IDictionary<string, IList<ModelValidationError>> Errors { get; set; }

        public ValidateViewModel()
        {
            Errors = new Dictionary<string, IList<ModelValidationError>>();
        }
    }
}