namespace ComputerConfigurator.Api.MotherboardFormFactor;

public partial class MotherboardFormFactor
{
    public Guid UUID { get; set; }
    public string FormFactor { get; set; } = string.Empty;

    public MotherboardFormFactor()
    {

    }

    public MotherboardFormFactor(DTO.Create MotherboardFormFactor)
    {
        UUID = MotherboardFormFactor.UUID;
        FormFactor = MotherboardFormFactor.FormFactor;
    }
}
