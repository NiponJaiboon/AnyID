using System;
using System.IO;
using System.Net;
using System.Text;
using System.Security.Cryptography.Pkcs;
using System.Security.Cryptography.X509Certificates;
using log4net;
using System.Net.Http;
using AnyIDModel;
using System.Collections.Generic;

namespace ITMXConnector
{
    public class ITMXRestClient
    {
        public const string ContentType = @"application/json";

        public static HttpStatusCode HttpGet(string url, out string response)
        {
            var itmxClient = new HttpClient();
            var uri = new Uri(url);
            var httpResponse = itmxClient.GetAsync(uri).Result;
            return ExtractResult(out response, httpResponse);
        }

        public static HttpStatusCode HttpPost(Uri endPoint, string content, out string response)
        {
            var utf8Content = new StringContent(content, Encoding.UTF8, ContentType);
            var itmxClient = new HttpClient();
            //itmxClient.DefaultRequestHeaders.Add(AuthKey, AuthValue);

            var httpResponse = itmxClient.PostAsync(endPoint, utf8Content).Result;
            return ExtractResult(out response, httpResponse);
        }

        public static HttpStatusCode HttpPut(Uri endPoint, string content, out string response)
        {
            var utf8Content = new StringContent(content, Encoding.UTF8, ContentType);
            var itmxClient = new HttpClient();
            //itmxClient.DefaultRequestHeaders.Add(AuthKey, AuthValue);

            var httpResponse = itmxClient.PutAsync(endPoint, utf8Content).Result;
            return ExtractResult(out response, httpResponse);
        }

        private static HttpStatusCode ExtractResult(out string response, HttpResponseMessage httpResponse)
        {
            if (httpResponse.StatusCode == HttpStatusCode.OK)
                response = httpResponse.Content.ReadAsStringAsync().Result;
            else
                response = httpResponse.ToString();
            return httpResponse.StatusCode;
        }
    }
}
