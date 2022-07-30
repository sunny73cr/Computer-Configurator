namespace ComputerConfigurator.Api.FanVoltage;

public partial class FanVoltage
{
    public Guid UUID { get; set; }
    public float Voltage { get; set; }

    public FanVoltage()
    {

    }

    public FanVoltage(DTO.Create FanVoltage)
    {
        UUID = FanVoltage.UUID;
        Voltage = FanVoltage.Voltage;
    }
}
