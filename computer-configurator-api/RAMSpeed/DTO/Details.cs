namespace ComputerConfigurator.Api.RAMSpeed.DTO
{
    public class Details
    {
        public Guid UUID { get; set; }
        public int ClockRate { get; set; }

        public Details()
        {

        }

        public Details(RAMSpeed RAMSpeed)
        {
            UUID = RAMSpeed.UUID;
            ClockRate = RAMSpeed.ClockRate;
        }
    }
}
