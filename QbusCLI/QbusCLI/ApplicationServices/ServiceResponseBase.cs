using System;
using System.Collections.Generic;
using System.Text;

namespace QbusCLI.ApplicationServices
{
    public abstract class ServiceResponseBase
    {
        public ServiceResponseBase()
        {
            this.Exception = null;
        }

        public Exception Exception { get; set; }
    }
}
