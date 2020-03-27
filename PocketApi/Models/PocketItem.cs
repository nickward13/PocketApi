using PocketApi.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace PocketApi.Models
{
    public class PocketItem
    {
        [JsonPropertyName("item_id")]
        public string Id { get; set; }

        [JsonPropertyName("resolved_id")]
        public string ResolvedId { get; set; }

        [JsonPropertyName("given_url")]
        public string GivenUrl { get; set; }

        [JsonPropertyName("given_title")]
        public string GivenTitle { get; set; }

        [JsonPropertyName("favorite")]
        public string Favorite { get; set; }

        [JsonPropertyName("status")]
        public string Status { get; set; }

        [JsonPropertyName("time_added")]
        public string TimeAdded { get; set; }

        [JsonPropertyName("time_updated")]
        public string TimeUpdated { get; set; }

        [JsonPropertyName("time_read")]
        public string TimeRead { get; set; }

        [JsonPropertyName("time_favorited")]
        public string TimeFavorited { get; set; }

        [JsonPropertyName("sort_id")]
        public int SortId { get; set; }

        [JsonPropertyName("resolved_title")]
        public string ResolvedTitle { get; set; }

        [JsonPropertyName("resolved_url")]
        public string ResolvedUrl { get; set; }

        [JsonPropertyName("excerpt")]
        public string Excerpt { get; set; }

        [JsonPropertyName("is_article")]
        public string IsArticle { get; set; }

        [JsonPropertyName("is_index")]
        public string IsIndex { get; set; }

        [JsonPropertyName("has_video")]
        public string HasVideo { get; set; }

        [JsonPropertyName("has_image")]
        public string HasImage { get; set; }

        [JsonPropertyName("word_count")]
        public string WordCount { get; set; }

        [JsonPropertyName("lang")]
        public string Lang { get; set; }

        [JsonPropertyName("time_to_read")]
        public int TimeToRead { get; set; }

        [JsonPropertyName("top_image_url")]
        public string TopImageUrl { get; set; }
        
        [JsonIgnore]
        public List<PocketAuthor> Authors { get; set; }
        
        [JsonPropertyName("image")]
        public PocketImage Image { get; set; }

        [JsonIgnore]
        public List<PocketImage> Images { get; set; }

        [JsonPropertyName("listen_duration_estimate")]
        public int ListenDurationEstimate { get; set; }

        override public string ToString()
        {
            return $"Item #{Id} - ({ResolvedTitle})";
        }
    }
}
