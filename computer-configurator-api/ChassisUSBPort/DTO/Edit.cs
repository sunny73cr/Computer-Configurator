namespace ComputerConfigurator.Api.ChassisUSBPort.DTO
{
    public class Edit
    {
        public Guid USBPortUUID { get; set; }
        public Guid ChassisZoneUUID { get; set; }
        public int Count { get; set; }

        public IReadOnlyList<string> Validate() => new Validation(this).Errors;
    }
}
