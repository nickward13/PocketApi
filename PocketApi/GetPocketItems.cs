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

        public static async Task<List<PocketItem>> ExecuteAsync(string consumerKey, AccessToken accessToken)
        {
            string apiResponse = await ApiPost.ExecuteAsync(
                _getUri,
                new GetPocketItemsBody()
                {
                    ConsumerKey = consumerKey,
                    AccessToken = accessToken.Token,
                    DetailType = "complete"
                });

            List<PocketItem> pocketItems = ConvertJsonToPocketItems(apiResponse);

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
    }
}
