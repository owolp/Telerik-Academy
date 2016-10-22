namespace HttpRequestFactory
{
    using System.Collections.Generic;

    public class HttpRequest : IHttpRequest
    {
        public HttpRequest(string method, string url, string[] customHeaders)
        {
            this.Method = method;
            this.Url = url;
            this.Headers = new Dictionary<string, string>();

            if (customHeaders != null)
            {
                for (int i = 0; i < customHeaders.Length; i += 2)
                {
                    this.Headers.Add(customHeaders[i], customHeaders[i + 1]);
                }
            }
        }

        public IDictionary<string, string> Headers { get; set; }

        public string Method { get; set; }

        public string Url { get; set; }

        public override string ToString()
        {
            return "HTTP Request";
        }
    }
}
