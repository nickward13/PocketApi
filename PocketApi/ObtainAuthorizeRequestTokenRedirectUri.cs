using System;
using System.Collections.Generic;
using System.Text;

namespace PocketApi
{
    public class ObtainAuthorizeRequestTokenRedirectUri
    {
        public static Uri Execute(RequestToken RequestToken, Uri RedirectUri)
        {
            Uri uri = new Uri($"https://getpocket.com/auth/authorize?request_token={RequestToken.Code}&redirect_uri={RedirectUri.ToString()}");
            return uri;
        }
    }
}
