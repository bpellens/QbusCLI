namespace QbusCLI.ApplicationServices
{
    public class SetStatusServiceRequest : ServiceRequestBase
    {
        public SetStatusInputModel Request { get; set; }
    }

    public class SetStatusInputModel
    {
        public int Output { get; set; }

        public int Value { get; set; }
    }
}