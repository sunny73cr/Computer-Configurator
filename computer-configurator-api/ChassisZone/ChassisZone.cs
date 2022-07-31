namespace ComputerConfigurator.Api.ChassisZone;

public partial class ChassisZone
{
    public Guid UUID { get; set; }
    public string Zone { get; set; } = string.Empty;

    public ChassisZone()
    {

    }

    public ChassisZone(DTO.Create ChassisZone)
    {
        UUID = ChassisZone.UUID;
        Zone = ChassisZone.Zone;
    }
}
