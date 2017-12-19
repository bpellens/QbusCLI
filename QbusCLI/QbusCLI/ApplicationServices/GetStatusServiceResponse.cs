namespace QbusCLI.ApplicationServices
{
    public class GetStatusServiceResponse : ServiceResponseBase
    {
        public StatusViewModel Response { get; set; }
    }

    public class StatusViewModel
    {
        public int Output { get; set; }

        public int Value { get; set; }
    }
}