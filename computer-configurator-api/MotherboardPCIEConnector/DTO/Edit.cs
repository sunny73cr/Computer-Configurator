namespace ComputerConfigurator.Api.MotherboardPCIEConnector.DTO
{
    public class Edit
    {
        public Guid PCIEConnectorUUID { get; set; }
        public int Count { get; set; }

        public IReadOnlyList<string> Validate() => new Validation(this).Errors;
    }
}
