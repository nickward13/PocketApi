# PocketApi
This is an API wrapper for the Pocket API available at https://getpocket.com/developer/.  Nuget package published to https://www.nuget.org/packages/Nickward13.PocketApi.

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