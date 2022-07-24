namespace ComputerConfigurator.Api.ChassisZone.DTO
{
    public class Details
    {
        public Guid UUID { get; set; }
        public string Zone { get; set; } = string.Empty;

        public Details()
        {

        }

        public Details(ChassisZone ChassisZone)
        {
            UUID = ChassisZone.UUID;
            Zone = ChassisZone.Zone;
        }
    }
}
