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

    public static void Edit(FanDiameter FanDiameter, DTO.Edit edits)
    {
        if (FanDiameter.Diameter != edits.Diameter) FanDiameter.Diameter = edits.Diameter;
    }
}
