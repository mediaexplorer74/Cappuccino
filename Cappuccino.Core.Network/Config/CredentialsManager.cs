﻿using System;
using Cappuccino.Core.Network.Auth;
using Cappuccino.Core.Network.Handlers;
using Cappuccino.Core.Network.Internal;

namespace Cappuccino.Core.Network.Config {

    public static class CredentialsManager {
        internal static ApiConfiguration? ApiConfig { get; private set; }

        private static AccessToken? _accessToken;
        internal static AccessToken? AccessToken {
            get {
                if (_accessToken == null) 
                    _accessToken = ApiConfig?.TokenStorageHandler?.OnTokenRequested();
                return _accessToken;
            }
            private set {
                if (_accessToken != null) 
                    ApiConfig?.TokenStorageHandler?.OnTokenReceived(value!);
                _accessToken = value;
               
            }
        }

        public static int CurrentUserId => AccessToken?.UserId ?? 0;


        public static void ApplyConfiguration(ApiConfiguration config) {
            ApiConfig = config;
            AccessToken = null;
        }
        public static bool ApplyAccessToken(AccessToken? token, IValidationCallback? callback = null) {
            if (!IsTokenValid(token, callback)) 
                return false;
                
            AccessToken = token;
            return true;
        }


        public static bool IsInternalTokenValid(IValidationCallback? callback = null) {
            if (ApiConfig?.TokenStorageHandler == null) {
                callback?.OnValidationFail($"Implementation of {nameof(ITokenStorageHandler)} does not find");
                return false;
            }

            if (AccessToken != null)
                return IsTokenValid(AccessToken, callback);

            return false;
        }
        
        internal static bool IsTokenValid(AccessToken? token, IValidationCallback? callback = null) {
            if (token == null) {
                callback?.OnValidationFail("Instance of token is null");
                return false;
            }
            
            if (token.ExpiresIn < DateTimeOffset.Now.ToUnixTimeSeconds() && token.ExpiresIn != -1) {
                callback?.OnValidationFail("Token lifetime is expired. Re-sign required");
                return false;
            }

            if (token.Token.Equals(string.Empty)) {
                callback?.OnValidationFail("Access token is empty");
                return false;
            }

            return true;
        }
    }
}