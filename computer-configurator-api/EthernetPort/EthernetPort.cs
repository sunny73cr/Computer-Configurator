namespace ComputerConfigurator.Api.EthernetPort;

public partial class EthernetPort
{
    public Guid UUID { get; set; }
    public string Chipset { get; set; } = string.Empty;
    public int BandwidthMBytes { get; set; }

    public EthernetPort()
    {

    }

    public EthernetPort(DTO.Create EthernetPort)
    {
        UUID = EthernetPort.UUID;
        Chipset = EthernetPort.Chipset;
        BandwidthMBytes = EthernetPort.BandwidthMBytes;
    }
}
