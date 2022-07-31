namespace ComputerConfigurator.Api.GPU.DTO
{
    public class Edit : Part.DTO.Edit
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

        public override IReadOnlyList<string> Validate() => new Validation(this).Errors;
    }
}
