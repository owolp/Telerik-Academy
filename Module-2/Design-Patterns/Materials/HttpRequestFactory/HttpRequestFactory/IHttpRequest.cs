namespace HttpRequestFactory
{
    using System.Collections.Generic;

    public interface IHttpRequest
    {
        string Method { get; set; }

        string Url { get; set; }

        IDictionary<string, string> Headers { get; set; }
    }
}