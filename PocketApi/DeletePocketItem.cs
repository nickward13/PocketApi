using PocketApi.Auth;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace PocketApi
{
    public class DeletePocketItem
    {
        private static Uri _modifyUri = new Uri($"https://getpocket.com/v3/send");

        public static async Task<bool> ExecuteAsync(string consumerKey, AccessToken accessToken, PocketItem deletePocketItem)
        {
            string apiResponse = await ApiPost.ExecuteAsync(
                _modifyUri,
                new ModifyPocketItemBody()
                {
                    ConsumerKey = consumerKey,
                    AccessToken = accessToken.Token,
                    Actions = new PocketModifyAction[]
                    {
                        new PocketModifyAction()
                        {
                            Action = PocketModifyActionType.Delete,
                            ItemId = deletePocketItem.Id
                        }
                    }
                });

            JsonDocument apiJsonDocument = JsonDocument.Parse(apiResponse);
            foreach (JsonProperty property in apiJsonDocument.RootElement.EnumerateObject())
            {
                if (property.Name == "status")
                {
                    if (property.Value.GetDouble() != 1)
                        return false;
                    else
                        return true;
                }
            }

            return false;
        }
    }
}
