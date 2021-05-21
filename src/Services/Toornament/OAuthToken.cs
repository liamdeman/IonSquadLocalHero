using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Proj2Aalst_G3.Services.Toornament
{
    public class OAuthToken
    {
        [JsonProperty("scope")] public string Scope { get; init; }

        [JsonProperty("token_type")] public string TokenType { get; init; }

        [JsonProperty("expires_in")] public int ExpiresIn { get; init; }

        [JsonProperty("access_token")] public string AccessToken { get; init; }

        public bool IsExpired => created.AddSeconds(ExpiresIn).CompareTo(DateTime.Now) <= 0;

        private DateTime created;

        public OAuthToken()
        {
            created = DateTime.Now;
        }
    }
}