﻿namespace Processing_JSON_in_.NET
{
    using Newtonsoft.Json;

    public class Video : IVideo
    {
        [JsonProperty("title")]
        public string Title { get; set; }

        public override string ToString()
        {
            return $"Item: Title: {this.Title}";
        }
    }
}
