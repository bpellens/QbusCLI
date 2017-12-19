using System;
using System.Collections.Generic;
using System.Text;

namespace QbusCLI.ApplicationServices
{
    interface IQbusService
    {
        LoginServiceResponse Login(LoginServiceRequest request);
        GetStatusServiceResponse GetStatus(GetStatusServiceRequest request);
        SetStatusServiceResponse SetStatus(SetStatusServiceRequest request);
    }
}
