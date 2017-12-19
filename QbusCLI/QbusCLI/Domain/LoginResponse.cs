using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace QbusCLI.Domain
{
    class LoginResponse
    {
        [JsonProperty("rsp")]
        public bool Response { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }
    }
}
