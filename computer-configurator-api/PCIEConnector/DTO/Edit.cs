namespace ComputerConfigurator.Api.PCIEConnector.DTO
{
    public class Edit
    {
        public Guid UUID { get; set; } = Guid.Empty;
        public Guid PCIEGenerationUUID { get; set; }
        public int LaneCount { get; set; }

        public IReadOnlyList<string> Validate() => new Validation(this).Errors;
    }
}
