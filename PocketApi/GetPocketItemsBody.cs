using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace PocketApi
{
    internal class GetPocketItemsBody
    {
        [JsonPropertyName("consumer_key")]
        public string ConsumerKey { get; set; }
        [JsonPropertyName("access_token")]
        public string AccessToken { get; set; }
        [JsonPropertyName("count")]
        public int Count { get; set; }
        [JsonPropertyName("detailType")]
        public string DetailType { get; set; }
        [JsonPropertyName("since")]
        public double Since { get; set; }
    }
}
