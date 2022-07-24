namespace ComputerConfigurator.Api.DisplayConnector.DTO
{
    public class Details
    {
        public Guid UUID { get; set; }
        public string Interface { get; set; } = null!;
        public string Version { get; set; } = null!;

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
