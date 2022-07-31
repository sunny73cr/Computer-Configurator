namespace ComputerConfigurator.Api.MotherboardPCIEConnector.DTO
{
    public class Create
    {
        public Guid PCIEConnectorUUID { get; set; }
        public int Count { get; set; }

        public IReadOnlyList<string> Validate() => new Validation(this).Errors;
    }
}
