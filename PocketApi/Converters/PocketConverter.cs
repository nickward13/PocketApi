using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace PocketApi.Converters
{
    internal class PocketConverter
    {
        public static PocketItem ConvertJsonToPocketItem(JsonProperty itemObject)
        {
            var itemJsonDocument = JsonDocument.Parse(itemObject.Value.ToString());

            PocketItem pocketItem = JsonSerializer.Deserialize<PocketItem>(itemJsonDocument.RootElement.ToString());

            JsonElement authorsJsonElement;
            if (itemJsonDocument.RootElement.TryGetProperty("authors", out authorsJsonElement))
                pocketItem.Authors = ConvertJsonToAuthors(itemJsonDocument.RootElement.GetProperty("authors"));
            else
                pocketItem.Authors = new List<PocketAuthor>();

            JsonElement imagesJsonElement;
            if (itemJsonDocument.RootElement.TryGetProperty("images", out imagesJsonElement))
                pocketItem.Images = ConvertJsonToImages(itemJsonDocument.RootElement.GetProperty("images"));
            else
                pocketItem.Images = new List<PocketImage>();
            return pocketItem;
        }

        private static List<PocketAuthor> ConvertJsonToAuthors(JsonElement json)
        {
            List<PocketAuthor> authors = new List<PocketAuthor>();

            foreach (var itemObject in json.EnumerateObject())
            {
                var itemJsonDocument = JsonDocument.Parse(itemObject.Value.ToString());
                PocketAuthor author = JsonSerializer.Deserialize<PocketAuthor>(itemJsonDocument.RootElement.ToString());
                authors.Add(author);
            }

            return authors;
        }

        private static List<PocketImage> ConvertJsonToImages(JsonElement json)
        {
            List<PocketImage> images = new List<PocketImage>();

            foreach (var itemObject in json.EnumerateObject())
            {
                var itemJsonDocument = JsonDocument.Parse(itemObject.Value.ToString());
                PocketImage image = JsonSerializer.Deserialize<PocketImage>(itemJsonDocument.RootElement.ToString());
                images.Add(image);
            }

            return images;
        }
    }
}
