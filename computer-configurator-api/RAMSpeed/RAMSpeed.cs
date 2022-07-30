namespace ComputerConfigurator.Api.RAMSpeed;

public partial class RAMSpeed
{
    public Guid UUID { get; set; }
    public int ClockRate { get; set; }

    public RAMSpeed()
    {

    }

    public RAMSpeed(DTO.Create RAMSpeed)
    {
        UUID = RAMSpeed.UUID;
        ClockRate = RAMSpeed.ClockRate;
    }
}
