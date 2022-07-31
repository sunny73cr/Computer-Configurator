namespace ComputerConfigurator.Api.MotherboardChipset.DTO
{
    public class Create
    {
        public Guid UUID { get; set; } = Guid.NewGuid();
        public Guid CPUSocketUUID { get; set; }
        public Guid ManufacturerUUID { get; set; }
        public string Version { get; set; } = string.Empty;

        public IReadOnlyList<string> Validate() => new Validation(this).Errors;
    }
}
