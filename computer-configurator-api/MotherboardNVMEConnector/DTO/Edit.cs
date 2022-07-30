namespace ComputerConfigurator.Api.MotherboardNVMEConnector.DTO
{
    public class Edit
    {
        public Guid PCIEGenerationUUID { get; set; }
        public Guid NVMEInterfaceUUID { get; set; }
        public Guid NVMEFormFactorUUID { get; set; }
        public int Count { get; set; }

        public IReadOnlyList<string> Validate() => new Validation(this).Errors;
    }
}
