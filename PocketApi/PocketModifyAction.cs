using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace PocketApi
{
    internal class PocketModifyAction
    {
        [JsonIgnore]
        public PocketModifyActionType Action { get; set; }
        [JsonPropertyName("action")]
        public string ActionString
        {
            get
            {
                return Action.ToString().ToLower();
            }
        }

        [JsonPropertyName("item_id")]
        public string ItemId { get; set; }
        
        [JsonPropertyName("time")]
        public string UnixTimestamp { get; set; }
    }
}
