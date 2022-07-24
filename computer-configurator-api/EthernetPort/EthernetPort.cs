namespace ComputerConfigurator.Api.EthernetPort;

public partial class EthernetPort
{
    public Guid UUID { get; set; }
    public string Chipset { get; set; } = null!;
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

    public static void Edit(EthernetPort EthernetPort, DTO.Edit edits)
    {
        if (EthernetPort.Chipset != edits.Chipset) EthernetPort.Chipset = edits.Chipset;
        if (EthernetPort.BandwidthMBytes != edits.BandwidthMBytes) EthernetPort.BandwidthMBytes = edits.BandwidthMBytes;
    }
}
