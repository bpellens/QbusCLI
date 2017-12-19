using System;
using System.Collections.Generic;
using System.Text;

namespace QbusCLI.Domain
{
    class Payload<T>
    {
        public PayloadType Type { get; set; }

        public T Value { get; set; }
    }
}
