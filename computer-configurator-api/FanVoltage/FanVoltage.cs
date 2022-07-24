namespace ComputerConfigurator.Api.FanVoltage;

public partial class FanVoltage
{
    public Guid UUID { get; set; }
    public int Voltage { get; set; }

    public FanVoltage()
    {

    }

    public FanVoltage(DTO.Create FanVoltage)
    {
        UUID = FanVoltage.UUID;
        Voltage = FanVoltage.Voltage;
    }

    public static void Edit(FanVoltage FanVoltage, DTO.Edit edits)
    {
        if (FanVoltage.Voltage != edits.Voltage) FanVoltage.Voltage = edits.Voltage;
    }
}
