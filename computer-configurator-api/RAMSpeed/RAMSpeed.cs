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

    public static void Edit(RAMSpeed RAMSpeed, DTO.Edit edits)
    {
        if (RAMSpeed.ClockRate != edits.ClockRate) RAMSpeed.ClockRate = edits.ClockRate;
    }
}
