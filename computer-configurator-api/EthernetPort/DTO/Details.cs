namespace ComputerConfigurator.Api.EthernetPort.DTO
{
    public class Details
    {
        public Guid UUID { get; set; }
        public string Chipset { get; set; } = string.Empty;
        public int BandwidthMBytes { get; set; }

        public Details()
        {

        }

        public Details(EthernetPort EthernetPort)
        {
            UUID = EthernetPort.UUID;
            Chipset = EthernetPort.Chipset;
            BandwidthMBytes = EthernetPort.BandwidthMBytes;
        }
    }
}
