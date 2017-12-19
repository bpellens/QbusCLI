namespace QbusCLI.ApplicationServices
{
    public class LoginServiceRequest : ServiceRequestBase
    {
        public LoginInputModel Request { get; set; }
    }

    public class LoginInputModel
    {
        public string Username { get; set; }

        public string Password { get; set; }
    }
}