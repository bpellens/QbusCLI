using AutoMapper;
using McMaster.Extensions.CommandLineUtils;
using QbusCLI.ApplicationServices;
using QbusCLI.Data;
using QbusCLI.Domain;
using QbusCLI.Infrastructure;
using RestSharp;
using System;
using System.Net;

namespace QbusCLI
{
    [HelpOption(Template = "-?")]
    public class Program
    {
        public static int Main(string[] args) => CommandLineApplication.Execute<Program>(args);

        [Option(Description = "The host")]
        public string Host { get; }

        [Option(Description = "The username")]
        public string Username { get; }

        [Option(Description = "The password")]
        public string Password { get; }

        [Option(Description = "The output")]
        public int Output { get; }

        [Option(Description = "The value")]
        public int Value { get; }

        private void OnExecute()
        {
            // Default host set to the one used in the Qbus App (don't know if it is any good).
            const string defaultHost = "http://192.168.0.115:8444";

            Mapper.Initialize(cfg =>
            {
                cfg.AddProfile<AppProfile>();
            });
            
            IRestClient client = new RestClient(Host ?? defaultHost)
            {
                CookieContainer = new CookieContainer()
            };

            IQbusApi api = new QbusApi(client);
            IQbusService service = new QbusService(api, Mapper.Instance);
            
            var account = new LoginInputModel() { Username = Username ?? "", Password = Password ?? "" };

            var loginResult = service.Login(new LoginServiceRequest() { Request = account });

            if (loginResult.Exception != null)
            {
                Console.WriteLine(loginResult.Exception.Message);
                return;
            }

            Cookie session = new Cookie() { Name = "i", Value = loginResult.Response.SessionId, Domain = client.BaseUrl.Host };
            client.CookieContainer.Add(session);

            var input = new SetStatusInputModel() { Output = Output, Value = Value };
            var setStatusResult = service.SetStatus(new SetStatusServiceRequest() { Request = input });

            if (setStatusResult.Exception != null)
            {
                Console.WriteLine(setStatusResult.Exception.Message);
                return;
            }

            Console.WriteLine("Command completed!");
        }
    }
}
