using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace PocketApi.Models
{
    public class AccessToken
    {
        [JsonPropertyName("access_token")]
        public string Token { get; set; }
        [JsonPropertyName("username")]
        public string Username { get; set; }
        [JsonIgnore]
        public string ConsumerKey { get; set; }
    }
}
