
namespace ContactManagement.MvcClient.Helper
{
    using Newtonsoft.Json;
    using System;
    using System.Net.Http;
    using System.Net.Http.Headers;

    public static class HttpRequestHelper
    {
        #region "Methods"
        internal static HttpRequestMessage CreateHttpRequest<TRequest>(HttpMethod verb, Uri uri, TRequest requestContent)
        {
            var request = new HttpRequestMessage()
            {
                RequestUri = uri,
                Method = verb
            };

            string content = JsonConvert.SerializeObject(requestContent);
            request.Content = new StringContent(content);
            request.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            return request;
        }

        #endregion
    }
}
