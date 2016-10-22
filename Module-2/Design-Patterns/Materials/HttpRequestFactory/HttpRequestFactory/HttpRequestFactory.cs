namespace HttpRequestFactory
{
    using System.Linq;

    public class HttpRequestFactory
    {
        public static IHttpRequest CreateRequest(string method, string url, string[] customHeaders = null, string mimeType = "*/*", string body = "")
        {
            if (new string[] { "get", "options" }.Contains(method))
            {
                return new HttpRequest(method, url, customHeaders);
            }

            return new HttpRequestWithBody(method, url, customHeaders, mimeType, body);
        }
    }
}
