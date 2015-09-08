using Nancy;

namespace SmartFlow.Extensions
{
    public static class NancyExtensions
    {
        public static void AddValidationError(this NancyModule module, string propertyName, string errorMessage)
        {
            module.ModelValidationResult.Errors.Add(propertyName, errorMessage);
        }
    }
}