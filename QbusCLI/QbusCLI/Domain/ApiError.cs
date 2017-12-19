using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace QbusCLI.Domain
{
    class ApiError
    {
        [JsonProperty("Error")]
        public int Error { get; set; }

        public string ToMessage()
        {
            string result = "";

            switch (this.Error)
            {
                case 1:
                    result = "The controller is busy, please try again later";
                    break;
                case 2:
                    result = "Your session timed out. Please login again";
                    break;
                case 3:
                    result = "Too much devices are connected to the controller.";
                    break;
                case 4:
                    result = "The controller was unable to execute your command.";
                    break;
                case 5:
                    result = "Your session could not be started";
                    break;
                case 6:
                    result = "The command is unknown";
                    break;
                case 7:
                    result = "No EQOweb configuration found, please run System manager to upload and configure EQOweb.";
                    break;
                case 8:
                    result = "System manager is still connected. Please close System manager to continue";
                    break;
                case 255:
                    result = "Undefined error in the controller. Please try again later";
                    break;
                default:
                    result = "Undefined error in the controller. Please try again later";
                    break;
            };

            return result;
        }

    }
}
