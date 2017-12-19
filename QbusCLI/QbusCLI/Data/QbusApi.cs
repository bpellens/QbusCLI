using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using QbusCLI.Domain;
using RestSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace QbusCLI.Data
{
    class QbusApi : IQbusApi
    {   
        private IRestClient _client;
        private Random _randomizer = new Random();

        public QbusApi(IRestClient client)
        {
            _client = client;
        }

        public Payload<LoginResponse> Login(Payload<LoginRequest> request)
        {
            var payload = Serialize(request);

            var result = Execute(payload);

            return Deserialize<Payload<LoginResponse>>(result);
        }

        public Payload<GetStatusResponse> GetStatus(Payload<GetStatusRequest> request)
        {
            var payload = Serialize(request);

            var result = Execute(payload);

            return Deserialize<Payload<GetStatusResponse>>(result);
        }

        public Payload<SetStatusResponse> SetStatus(Payload<SetStatusRequest> request)
        {
            var payload = Serialize(request);

            var result = Execute(payload);

            return Deserialize<Payload<SetStatusResponse>>(result);
        }
        
        public string Execute(string payload)
        {
            var r = _randomizer.NextDouble().ToString();

            var request = new RestRequest("default.aspx", Method.POST);
            request.AddHeader("Content-type", "application/x-www-form-urlencoded");
            request.AddQueryParameter("r", r);
            request.AddParameter("strJSON", payload);
            
            IRestResponse response = _client.Execute(request);

            if (response.ErrorException != null)
            {
                throw new Exception("Error retrieving response. Check inner details for more info.", response.ErrorException);
            }
            
            return response.Content;
        }

        private T Deserialize<T>(string content)
        {
            try
            {
                // Take a peek at the type
                var deserializedBody = JsonConvert.DeserializeObject<Payload<JObject>>(content);

                // If an error, throw an exception
                if (deserializedBody.Type == PayloadType.Error)
                {
                    ApiError error = deserializedBody.Value.ToObject<ApiError>();
                    throw new Exception("An error occurred. Check inner details for more info.", new Exception(error.ToMessage()));
                }

                // Deserialize to the correct type
                return JsonConvert.DeserializeObject<T>(content);
            }
            catch (Exception e)
            {
                throw new Exception("Error deserializing the response.", e);

            }
        }

        private string Serialize(object obj)
        {
            try
            {
                return obj != null ? JsonConvert.SerializeObject(obj) : null;
            }
            catch (Exception e)
            {
                throw new Exception("Error serializing the payload.", e);
            }
        }
    }
}
