namespace HttpRequestFactory
{
    public class HttpRequestWithBody : HttpRequest, IHttpRequestWithBody
    {
        public HttpRequestWithBody(string method, string url, string[] customHeaders, string mimeType, string body)
            : base(method, url, customHeaders)
        {
            this.MimeType = mimeType;
            this.Body = body;
        }

        public string Body { get; set; }

        public string MimeType { get; set; }

        public override string ToString()
        {
            return "HTTP Request With Body";
        }
    }
}
