namespace HttpRequestFactory
{
    using System;
    using System.Collections.Generic;

    public class Program
    {
        private static void Main()
        {
            var requests = new List<IHttpRequest>()
            {
                HttpRequestFactory.CreateRequest("get", "google.com"),
                HttpRequestFactory.CreateRequest("invalid", "hello")
            };

            foreach (var request in requests)
            {
                Console.WriteLine(request);
            }
        }
    }
}