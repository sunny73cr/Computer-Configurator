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

    public static void Edit(PowerSupplyFormFactor PowerSupplyFormFactor, DTO.Edit edits)
    {
        if (PowerSupplyFormFactor.FormFactor != edits.FormFactor) PowerSupplyFormFactor.FormFactor = edits.FormFactor;
    }
}
