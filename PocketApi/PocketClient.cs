﻿using PocketApi.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PocketApi
{
    public partial class PocketClient
    {
        private AccessToken _accessToken;

        public PocketClient(AccessToken accessToken)
        {
            _accessToken = accessToken;
        }

        public PocketClient()
        { }

    }
}