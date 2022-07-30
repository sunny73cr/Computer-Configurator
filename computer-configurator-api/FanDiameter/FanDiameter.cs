namespace ComputerConfigurator.Api.FanDiameter;

public partial class FanDiameter
{
    public Guid UUID { get; set; }
    public int Diameter { get; set; }

    public FanDiameter()
    {

    }

    public FanDiameter(DTO.Create FanDiameter)
    {
        UUID = FanDiameter.UUID;
        Diameter = FanDiameter.Diameter;
    }
}
