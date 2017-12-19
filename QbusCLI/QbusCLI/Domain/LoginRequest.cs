using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace QbusCLI.Domain
{
    class LoginRequest
    {
        [JsonProperty("Usr")]
        public string Username { get; set; }

        [JsonProperty("Psw")]
        public string Password { get; set; }
    }
}
