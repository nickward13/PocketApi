using PocketApi.Auth;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;

namespace PocketApi
{
    public class GetPocketItems
    {
        private static Uri _getUri = new Uri($"https://getpocket.com/v3/get");

        public static async Task<List<PocketItem>> ExecuteAsync(string consumerKey, AccessToken accessToken, DateTime lastSyncDateTime)
        {
            double lastSyncUnixTimestamp = Converters.UnixTimestampConverter.ToUnixtimestamp(lastSyncDateTime);

            string apiResponse = await ApiPost.ExecuteAsync(
                _getUri,
                new GetPocketItemsBody()
                {
                    ConsumerKey = consumerKey,
                    AccessToken = accessToken.Token,
                    DetailType = "complete",
                    Since = lastSyncUnixTimestamp,
                    StateEnum = PocketItemState.All
                });

            List<PocketItem> pocketItems = ConvertJsonToPocketItems(apiResponse);

            return pocketItems;
        }

        public static async Task<List<PocketItem>> ExecuteAsync(string consumerKey, AccessToken accessToken)
        {
            List<PocketItem> pocketItems = await ExecuteAsync(consumerKey, accessToken, new DateTime(1970, 1, 1));
            return pocketItems;
        }

        private static List<PocketItem> ConvertJsonToPocketItems(string json)
        {
            List<PocketItem> pocketItems = new List<PocketItem>();

            JsonDocument apiJsonDocument = JsonDocument.Parse(json);
            
            foreach(var itemObject in apiJsonDocument.RootElement.GetProperty("list").EnumerateObject())
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

                pocketItems.Add(pocketItem);
            }

            return pocketItems;
        }

        private static List<PocketAuthor> ConvertJsonToAuthors(JsonElement json)
        {
            List<PocketAuthor> authors = new List<PocketAuthor>();
            
            foreach(var itemObject in json.EnumerateObject())
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

            foreach(var itemObject in json.EnumerateObject())
            {
                var itemJsonDocument = JsonDocument.Parse(itemObject.Value.ToString());
                PocketImage image = JsonSerializer.Deserialize<PocketImage>(itemJsonDocument.RootElement.ToString());
                images.Add(image);
            }

            return images;
        }
    }
}
