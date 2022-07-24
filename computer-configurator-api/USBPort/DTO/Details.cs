namespace ComputerConfigurator.Api.USBPort.DTO
{
    public class Details
    {
        public Guid UUID { get; set; }
        public string Interface { get; set; } = string.Empty;
        public string Version { get; set; } = string.Empty;

        public Details()
        {

        }

        public Details(USBPort USBPort)
        {
            UUID = USBPort.UUID;
            Interface = USBPort.Interface;
            Version = USBPort.Version;
        }
    }
}
