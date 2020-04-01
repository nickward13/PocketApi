# PocketApi
This is an API wrapper for the Pocket API available at https://getpocket.com/developer/.  Nuget package published to https://www.nuget.org/packages/Nickward13.PocketApi.

## Overview and Instantiation
This API wrapper works via a PocketClient class.  PocketClient objects need to be authenticated prior to making any method calls to retrieve, add or modify pocket items, which are represented by the Models.PocketItem class.

To instantiate a PocketClient object, you can either pass a platform consumer key provided by Pocket, or provide an AccessToken object which has previously been returned to you from the ObtainAccessToken method on the PocketClient task.  See the Authentication section below for more details.

## Authentication
This API wrapper is written to emulate the authentication process documented at https://getpocket.com/developer/docs/authentication.  To that point, follow those instructions with these additional comments:
1. Obtain a platform consumer key as per the getpocket api instructions and pass it to the PocketClient construtor.
```
PocketClient _pocketClient = new PocketClient(consumerKey);
```
2. Obtain a request token by making a call to ObtainRequestTokenAsync, passing in your callback Uri and the consumer key obtained in step 1.  For example, for a UWP app, you might call:
```
Uri callbackUri = WebAuthenticationBroker.GetCurrentApplicationCallbackUri();
RequestToken requestToken = await _pocketClient.ObtainRequestTokenAsync(
    callbackUri);
```
3. Redirect user to Pocket to continue authorization using the uri returned from ObtainAuthorizeRequestTokenRedirectUri.  For example, for a UWP app, you might call:
```
Uri requestUri = _pocketClient.ObtainAuthorizeRequestTokenRedirectUri(requestToken, callbackUri);
WebAuthenticationResult result = await WebAuthenticationBroker.AuthenticateSilentlyAsync(requestUri);
if (result.ResponseStatus != WebAuthenticationStatus.Success)
    result = await WebAuthenticationBroker.AuthenticateAsync(
        WebAuthenticationOptions.None,
        requestUri);
```
4. Receive the callback from Pocket, which is handled by the WebAuthenticationBroker class in the code in step 3 above.
5. Convert a request token into a Pocket access token via ObtainAccessTokenAsync, for example:
```
AccessToken token = await _pocketClient.ObtainAccessTokenAsync(requestToken);
```
Note: once you have an AccessToken, you can construct a new PocketClient object by passing it to the constructor and therefore not have to do any further authentication:
```
PocketClient _pocketClient = new PocketClient(accessToken);
```
6. You can now make authenticated calls to Pocket using this AccessToken (which is stored in the PocketClient object, so you don't have to pass it to PocketClient each time).

## Adding items to Pocket
To add a new item to your Pocket, you can call the AddPocketItemAsync method, passing in a Uri for the item you wish to add, for example:
```
 PocketItem newPocketItem = await _pocketClient.AddPocketItemAsync(new Uri("https://www.theage.com.au/culture/comedy/the-at-home-comedy-festival-20200318-p54bhu.html"));
```

## Modifying items in Pocket
To modify an existing item in Pocket, you can call the following methods to archive, re-add, mark favorite, un-favorite and delete an item:
```
bool result;
result = await _pocketClient.ArchivePocketItemAsync(pocketItem);
result = await _pocketClient.ReAddPocketItemAsync(pocketItem);
result = await _pocketClient.MarkFavoritePocketItemAsync(pocketItem);
result = await _pocketClient.UnFavoritePocketItemAsync(pocketItem);
result = await _pocketClient.DeletePocketItemAsync(pocketItem);
```

## Retrieving items from Pocket
To retrieve a list of items in your pocket, there are two options.  You can retrieve all the items in your Pocket, or all the modified items in your pocket since the last time you retrieved your items.

To retrieve all items in your Pocket, issue the following code:
```
List<PocketItem> pocketItems = await _pocketClient.GetPocketItemsAsync();
```

To retrieve the modified items in your Pocket since your last retrieval, call the same method, but include the DateTime of your last retrieval.  All modified items will be retrieved since that date.  It is recommended you primarily use this function, rather than retrieving all the items in your Pocket with each call.
```
List<PocketItem> pocketItems = await _pocketClient.GetPocketItemsAsync(new DateTime(2020,1,1));
```