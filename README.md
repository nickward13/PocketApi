# PocketApi
This is an API wrapper for the Pocket API available at https://getpocket.com/developer/

## Authentication
This API wrapper is written to emulate the authentication process documented at https://getpocket.com/developer/docs/authentication.  To that point, follow those instructions with these additional comments:
1. Obtain a platform consumer key as per the getpocket api instructions
2. Obtain a request token by making a call to PocketApi.Auth.ObtainRequestToken, passing in your callback Uri and the consumer key obtained in step 1.  For example, for a UWP app, you might call:
```
Uri callbackUri = WebAuthenticationBroker.GetCurrentApplicationCallbackUri();
RequestToken requestToken = await ObtainRequestToken.ExecuteAsync(
    callbackUri,
    Secrets.PocketAPIConsumerKey);
```
3. Redirect user to Pocket to continue authorization using the uri returned from PocketApi.Auth.ObtainAuthorizeRequestTokenRedirectUri.  For example, for a UWP app, you might call:
```
Uri requestUri = ObtainAuthorizeRequestTokenRedirectUri.Execute(requestToken, callbackUri);
WebAuthenticationResult result = await WebAuthenticationBroker.AuthenticateSilentlyAsync(requestUri);
if (result.ResponseStatus != WebAuthenticationStatus.Success)
    result = await WebAuthenticationBroker.AuthenticateAsync(
        WebAuthenticationOptions.None,
        requestUri);
```
4. Receive the callback from Pocket, which is handled by the WebAuthenticationBroker class in the code in step 3 above.
5. Convert a request token into a Pocket access token via PocketApi.Auth.ObtainAccessToken, for example:
```
AccessToken token = ObtainAccessToken(requestToken, Secrets.PocketAPIConsumerKey);
```
6. You can now make authenticated calls to Pocket using this AccessToken