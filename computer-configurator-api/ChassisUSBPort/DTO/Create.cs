namespace ComputerConfigurator.Api.ChassisUSBPort.DTO
{
    public class Create
    {
        public Guid USBPortUUID { get; set; }
        public Guid ChassisZoneUUID { get; set; }
        public int Count { get; set; }

        public IReadOnlyList<string> Validate() => new Validation(this).Errors;
    }
}
