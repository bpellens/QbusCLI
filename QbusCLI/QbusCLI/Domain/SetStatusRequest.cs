﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace QbusCLI.Domain
{
    class SetStatusRequest
    {
        [JsonProperty("Chnl")]
        public int Channel { get; set; }

        [JsonProperty("Val")]
        public List<int> Values { get; set; }
    }
}
