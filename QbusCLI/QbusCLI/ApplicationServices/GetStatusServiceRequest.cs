namespace QbusCLI.ApplicationServices
{
    public class GetStatusServiceRequest : ServiceRequestBase
    {
        public GetStatusInputModel Request { get; set; }
    }

    public class GetStatusInputModel
    {
        public int Output { get; set; }
    }
}