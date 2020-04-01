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
        
        public async Task<bool> DeletePocketItemAsync(PocketItem deletePocketItem)
        {
            PocketModifyAction pocketDeleteAction = new PocketModifyAction()
            {
                Action = PocketModifyActionType.Delete,
                ItemId = deletePocketItem.Id
            };

            return await ModifyPocketItemAsync(pocketDeleteAction);
        }
    }
}
