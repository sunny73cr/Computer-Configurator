namespace ComputerConfigurator.Api.NVMEInterface;

public partial class NVMEInterface
{
    public Guid UUID { get; set; }
    public string Interface { get; set; } = string.Empty;

    public NVMEInterface()
    {

    }

    public NVMEInterface(DTO.Create NVMEInterface)
    {
        UUID = NVMEInterface.UUID;
        Interface = NVMEInterface.Interface;
    }
}
