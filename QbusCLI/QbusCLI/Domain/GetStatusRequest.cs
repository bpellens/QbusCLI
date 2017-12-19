using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace QbusCLI.Domain
{
    class GetStatusRequest
    {
        [JsonProperty("Chnl")]
        public int Channel { get; set; }
    }
}
