using System;
using System.Collections.Generic;
using System.Text;

namespace QbusCLI.Domain
{
    enum PayloadType
    {
        Error = 0,
        Login = 1,
        LoginResponse = 2,
        SetStatus = 12,
        SetStatusResponse = 13,
        GetStatus = 14,
        GetStatusResponse = 15
    }
}
