namespace HttpRequestFactory
{
    public interface IHttpRequestWithBody : IHttpRequest
    {
        string Body { get; set; }

        string MimeType { get; set; }
    }
}