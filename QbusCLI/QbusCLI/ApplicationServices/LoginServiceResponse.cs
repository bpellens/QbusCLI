namespace QbusCLI.ApplicationServices
{
    public class LoginServiceResponse : ServiceResponseBase
    {
        public LoginViewModel Response { get; set; }
    }

    public class LoginViewModel
    {
        public bool IsAuthenticated { get; set; }

        public string SessionId { get; set; }
    }
}