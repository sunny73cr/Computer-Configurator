namespace ComputerConfigurator.Api.Motherboard.DTO
{
    public class Edit : Part.DTO.Edit
    {
        public Guid CPUSocketUUID { get; set; }
        public int CPUSocketCount { get; set; }
        public Guid MotherboardFormFactorUUID { get; set; }
        public Guid MotherboardChipsetUUID { get; set; }
        public bool WifiSupport { get; set; }
        public int MaxRAMCapacityMByte { get; set; }

        public override IReadOnlyList<string> Validate() => new Validation(this).Errors;
    }
}
