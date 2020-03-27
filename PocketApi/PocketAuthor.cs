using System.Text.Json.Serialization;

namespace PocketApi
{
    public class PocketAuthor
    {
        [JsonPropertyName("author_id")]
        public string Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("url")]
        public string Url { get; set; }

        [JsonPropertyName("item_id")]
        public string ItemId { get; set; }

        public override string ToString()
        {
            return $"Author #{Id} - ({Name})";
        }
    }
}