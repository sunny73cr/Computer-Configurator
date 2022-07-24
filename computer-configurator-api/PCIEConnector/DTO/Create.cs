namespace ComputerConfigurator.Api.PCIEConnector.DTO
{
    public class Create
    {
        public Guid UUID { get; set; } = Guid.NewGuid();
        public Guid PCIEGenerationUUID { get; set; }
        public int LaneCount { get; set; }

        public IReadOnlyList<string> Validate() => new Validation(this).Errors;
    }
}
