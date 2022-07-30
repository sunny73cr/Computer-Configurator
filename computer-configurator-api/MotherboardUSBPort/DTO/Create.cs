namespace ComputerConfigurator.Api.MotherboardUSBPort.DTO
{
    public class Create
    {
        public Guid USBPortUUID { get; set; }
        public int ExternalCount { get; set; }
        public int InternalCount { get; set; }

        public IReadOnlyList<string> Validate() => new Validation(this).Errors;
    }
}
