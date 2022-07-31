namespace ComputerConfigurator.Api.NVMEFormFactor;

public partial class NVMEFormFactor
{
    public Guid UUID { get; set; }
    public string FormFactor { get; set; } = string.Empty;

    public NVMEFormFactor()
    {

    }

    public NVMEFormFactor(DTO.Create NVMEFormFactor)
    {
        UUID = NVMEFormFactor.UUID;
        FormFactor = NVMEFormFactor.FormFactor;
    }
}
