using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace PocketApi.Auth
{
    internal class ObtainAccessTokenBody
    {
        [JsonPropertyName("consumer_key")]
        public string ConsumerKey { get; set; }
        [JsonPropertyName("code")]
        public string RequestTokenCode { get; set; }
    }
}
