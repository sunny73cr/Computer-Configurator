namespace ComputerConfigurator.Api.FanVoltage.DTO
{
    public class Details
    {
        public Guid UUID { get; set; }
        public int Voltage { get; set; }

        public Details()
        {

        }

        public Details(FanVoltage FanVoltage)
        {
            UUID = FanVoltage.UUID;
            Voltage = FanVoltage.Voltage;
        }
    }
}
