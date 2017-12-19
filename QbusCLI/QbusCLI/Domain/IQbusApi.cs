using System;
using System.Collections.Generic;
using System.Text;

namespace QbusCLI.Domain
{
    interface IQbusApi
    {
        Payload<LoginResponse> Login(Payload<LoginRequest> request);
        Payload<GetStatusResponse> GetStatus(Payload<GetStatusRequest> request);
        Payload<SetStatusResponse> SetStatus(Payload<SetStatusRequest> request);
    }
}
