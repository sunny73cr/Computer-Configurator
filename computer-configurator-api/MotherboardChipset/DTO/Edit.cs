namespace ComputerConfigurator.Api.MotherboardChipset.DTO
{
    public class Edit
    {
        public Guid UUID { get; set; } = Guid.Empty;
        public Guid CPUSocketUUID { get; set; }
        public Guid ManufacturerUUID { get; set; }
        public string Version { get; set; } = null!;

        public IReadOnlyList<string> Validate() => new Validation(this).Errors;
    }
}
