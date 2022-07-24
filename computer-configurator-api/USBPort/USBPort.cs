namespace ComputerConfigurator.Api.USBPort;

public partial class USBPort
{
    public Guid UUID { get; set; }
    public string Interface { get; set; } = string.Empty;
    public string Version { get; set; } = string.Empty;

    public USBPort()
    {

    }

    public USBPort(DTO.Create USBPort)
    {
        UUID = USBPort.UUID;
        Interface = USBPort.Interface;
        Version = USBPort.Version;
    }

    public static void Edit(USBPort USBPort, DTO.Edit edits)
    {
        if (USBPort.Interface != edits.Interface) USBPort.Interface = edits.Interface;
    }
}
