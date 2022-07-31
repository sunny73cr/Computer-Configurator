namespace ComputerConfigurator.Api.MotherboardRAMSpeed
{
    public class MotherboardRAMSpeed
    {
        public Guid MotherboardUUID { get; set; }
        public Guid RAMSpeedUUID { get; set; }
        public bool RequiresOverclock { get; set; }

        public virtual Motherboard.Motherboard Motherboard { get; set; } = null!;
        public virtual RAMSpeed.RAMSpeed RAMSpeed { get; set; } = null!;

        public MotherboardRAMSpeed()
        {

        }

        public MotherboardRAMSpeed(Guid motherboardUUID, DTO.Create MotherboardRAMSpeed)
        {
            MotherboardUUID = motherboardUUID;
            RAMSpeedUUID = MotherboardRAMSpeed.RAMSpeedUUID;
            RequiresOverclock = MotherboardRAMSpeed.RequiresOverclock;
        }

        public static void Edit(MotherboardRAMSpeed MotherboardRAMSpeed, DTO.Edit edits)
        {
            if (MotherboardRAMSpeed.RequiresOverclock != edits.RequiresOverclock) MotherboardRAMSpeed.RequiresOverclock = edits.RequiresOverclock;
        }
    }
}
