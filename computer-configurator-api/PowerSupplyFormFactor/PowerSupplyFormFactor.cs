namespace ComputerConfigurator.Api.PowerSupplyFormFactor;

public partial class PowerSupplyFormFactor
{
    public Guid UUID { get; set; }
    public string FormFactor { get; set; } = string.Empty;

    public PowerSupplyFormFactor()
    {

    }

    public PowerSupplyFormFactor(DTO.Create PowerSupplyFormFactor)
    {
        UUID = PowerSupplyFormFactor.UUID;
        FormFactor = PowerSupplyFormFactor.FormFactor;
    }
}
