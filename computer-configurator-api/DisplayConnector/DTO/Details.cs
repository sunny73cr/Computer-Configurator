namespace ComputerConfigurator.Api.DisplayConnector.DTO
{
    public class Details
    {
        public Guid UUID { get; set; }
        public string Interface { get; set; } = string.Empty;
        public string Version { get; set; } = string.Empty;

        public Details()
        {

        }

        public Details(DisplayConnector DisplayConnector)
        {
            UUID = DisplayConnector.UUID;
            Interface = DisplayConnector.Interface;
            Version = DisplayConnector.Version;
        }
    }
}
