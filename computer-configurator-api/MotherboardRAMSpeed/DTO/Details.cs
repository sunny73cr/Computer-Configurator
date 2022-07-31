namespace ComputerConfigurator.Api.MotherboardRAMSpeed.DTO
{
    public class Details
    {
        public RAMSpeed.DTO.Details RAMSpeed { get; set; }
        public bool RequiresOverclock { get; set; }

        public Details(MotherboardRAMSpeed MotherboardRAMSpeed)
        {
            RAMSpeed = new RAMSpeed.DTO.Details(MotherboardRAMSpeed.RAMSpeed);
            RequiresOverclock = MotherboardRAMSpeed.RequiresOverclock;
        }
    }
}
