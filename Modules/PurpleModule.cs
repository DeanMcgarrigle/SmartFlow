using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using Nancy;
using ServiceStack.Text;
using SmartFlow.DTO.PurpleWifi;

namespace SmartFlow.Modules
{
    public class PurpleModule : NancyModule
    {

    }

    public class PurpleWifiConnection
    {
        private readonly string _publicKey;
        private readonly string _privateKey;
        private readonly string _domain;
        private readonly Encoding _encoding = Encoding.UTF8;

        public PurpleWifiConnection(string publicKey, string privateKey, string domain)
        {
            _publicKey = publicKey;
            _privateKey = privateKey;
            _domain = domain;
        }

        public T CreateRequest<T>(string url) where T : PurpleWifiResponse, new()
        {
            var date = DateTime.UtcNow;
            var sb = new StringBuilder();
            sb.AppendLine("application/json");
            sb.AppendLine(_domain);
            sb.AppendLine(string.Format("/api/company/v1{0}", url));
            sb.AppendLine(string.Format("{0} GMT", date.ToString("ddd, dd MMM yyyy HH:mm:ss")));
            sb.AppendLine(string.Empty);

            using (var hmacsha256 = new HMACSHA256(_encoding.GetBytes(_privateKey)))
            {
                hmacsha256.ComputeHash(_encoding.GetBytes(sb.ToString()));
                var hash = ByteToString(hmacsha256.Hash);

                var request = (HttpWebRequest)WebRequest.Create(string.Format("https://purpleportal.net/api/company/v1{0}", url));
                request.ContentType = "application/json";
                request.Date = date;
                request.Headers["X-API-Authorization"] = string.Format("{0}:{1}", _publicKey, hash);

                WebResponse res;
                try
                {
                    res = request.GetResponse();
                }
                catch (WebException ex)
                {
                    res = ex.Response;
                }

                using (var streamReader = new StreamReader(res.GetResponseStream()))
                {
                    var reader = streamReader.ReadToEnd();
                    try
                    {
                        return JsonSerializer.DeserializeFromString<T>(reader);
                    }
                    catch (Exception ex)
                    {
                        Debug.WriteLine(reader);
                        return new T();
                    }
                }
            }
        }

        private static string ByteToString(IEnumerable<byte> buff)
        {
            return buff.Aggregate("", (current, t) => current + t.ToString("x2"));
        }
    }
}