namespace ComputerConfigurator.Api.Chassis.DTO
{
    public class Edit : Part.DTO.Edit
    {
        public int LengthMM { get; set; }
        public int WidthMM { get; set; }
        public int HeightMM { get; set; }
        public int MaxGPULengthMM { get; set; }
        public int MaxPSULengthMM { get; set; }
        public int MaxCPUCoolerHeightMM { get; set; }
        public int PCIESlotCount { get; set; }

        public override IReadOnlyList<string> Validate() => new Validation(this).Errors;
    }
}
