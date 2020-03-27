using System;
using System.Text.Json.Serialization;

namespace PocketApi
{
    public class PocketImage
    {
        [JsonPropertyName("image_id")]
        public string Id { get; set; }

        [JsonPropertyName("src")]
        public string Source { get; set; }

        [JsonPropertyName("width")]
        public string WidthString { get; set; }
        public double Width {
            get
            {
                if (double.TryParse(WidthString, out double width))
                    return width;
                else
                    return 0;
            }
        }

        [JsonPropertyName("height")]
        public string HeightString { get; set; }
        public double Height
        {
            get
            {
                if (double.TryParse(HeightString, out double height))
                    return height;
                else
                    return 0;
            }
        }

        [JsonPropertyName("credit")]
        public string Credit { get; set; }

        [JsonPropertyName("caption")]
        public string Caption { get; set; }

        [JsonPropertyName("item_id")]
        public string ItemId { get; set; }
    }
}