using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace PocketApi.RestApiRequestModels
{
    internal class AddPocketItemBody
    {
        [JsonPropertyName("title")]
        public string Title { get; set; }

        [JsonIgnore]
        public List<string> Tags { get; set; }
        
        [JsonPropertyName("tags")]
        public string TagsString
        {
            get
            {
                if (Tags == null)
                    return "";

                string tagString = "";
                foreach(string tag in Tags)
                {
                    tagString = string.Concat(tagString, tag, ",");
                }
                return tagString;
            }
        }

        [JsonIgnore]
        public Uri Uri { get; set; }

        [JsonPropertyName("url")]
        public string UriString
        {
            get
            {
                return Uri.ToString();
            }
        }

        [JsonPropertyName("tweet_id")]
        public string TweetId { get; set; }
        
        [JsonPropertyName("consumer_key")]
        public string ConsumerKey { get; set; }
        
        [JsonPropertyName("access_token")]
        public string AccessToken { get; set; }
    }
}
