using PocketApi.Models;
using PocketApi.RestApiRequestModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace PocketApi
{
    public partial class PocketClient
    {
        private static Uri _modifyUri = new Uri($"https://getpocket.com/v3/send");

        private async Task<bool> ModifyPocketItemAsync(PocketModifyAction pocketModifyAction)
        {
            string apiResponse = await ApiPostAsync(
                _modifyUri,
                new ModifyPocketItemBody()
                {
                    ConsumerKey = _accessToken.ConsumerKey,
                    AccessToken = _accessToken.Token,
                    Actions = new PocketModifyAction[]
                    {
                        pocketModifyAction
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
