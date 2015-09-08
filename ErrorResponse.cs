using System;
using Nancy;
using Nancy.Responses;

namespace SmartFlow
{
    public class ErrorResponse : JsonResponse
    {
        readonly Error _error;

        private ErrorResponse(Error error)
            : base(error, new DefaultJsonSerializer())
        {
            _error = error;
        }

        public string ErrorMessage { get { return _error.ErrorMessage; } }
        public string FullException { get { return _error.FullException; } }
        public string[] Errors { get { return _error.Errors; } }

        public static ErrorResponse FromMessage(string message)
        {
            return new ErrorResponse(new Error { ErrorMessage = message });
        }

        public static ErrorResponse FromException(Exception ex)
        {
            var exception = ex.GetBaseException();
            var summary = exception.Message;
            const HttpStatusCode statusCode = HttpStatusCode.InternalServerError;
            var error = new Error { ErrorMessage = summary, FullException = exception.ToString() };
            var response = new ErrorResponse(error) { StatusCode = statusCode };

            return response;
        }

        class Error
        {
            public string ErrorMessage { get; set; }
            public string FullException { get; set; }
            public string[] Errors { get; set; }
        }
    }
}