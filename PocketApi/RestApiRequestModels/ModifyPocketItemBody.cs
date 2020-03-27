using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace PocketApi.RestApiRequestModels
{
    internal class ModifyPocketItemBody
    {
        [JsonPropertyName("consumer_key")]
        public string ConsumerKey { get; set; }

        [JsonPropertyName("access_token")]
        public string AccessToken { get; set; }

        [JsonPropertyName("actions")]
        public PocketModifyAction[] Actions { get; set; }

    }
}
