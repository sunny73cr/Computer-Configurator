namespace ComputerConfigurator.Api.GPU.DTO
{
    public class Create : Part.DTO.Create
    {
        public Guid PCIEConnectorUUID { get; set; }
        public int VRAMMBytes { get; set; }
        public int BaseClockSpeed { get; set; }
        public int? BoostClockSpeed { get; set; }
        public int MaxDisplayCount { get; set; }
        public int LengthMM { get; set; }
        public int WidthMM { get; set; }
        public int HeightMM { get; set; }
        public float SlotWidth { get; set; }
        public List<GPUDisplayConnector.DTO.Create> GPUDisplayConnectors { get; set; } = new();

        public override IReadOnlyList<string> Validate() => new Validation(this).Errors;
    }
}
