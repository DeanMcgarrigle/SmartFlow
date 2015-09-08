using System;
using System.IO;
using Nancy;

namespace SmartFlow.Extensions
{
    public class CsvResponse : CsvResponse<object>
    {
        public CsvResponse(object model, ISerializer serializer)
            : base(model, serializer)
        {
        }
    }

    public class CsvResponse<TModel> : Response
    {
        public CsvResponse(TModel model, ISerializer serializer)
        {
            if (serializer == null)
            {
                throw new InvalidOperationException("CSV Serializer not set");
            }

            Contents = GetJsonContents(model, serializer);
            ContentType = "text/csv";
            StatusCode = HttpStatusCode.OK;
        }

        private static Action<Stream> GetJsonContents(TModel model, ISerializer serializer)
        {
            return stream => serializer.Serialize("text/csv", model, stream);
        }
    }
}