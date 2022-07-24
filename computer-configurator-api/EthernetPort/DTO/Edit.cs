namespace ComputerConfigurator.Api.EthernetPort.DTO
{
    public class Edit
    {
        public Guid UUID { get; set; } = Guid.Empty;
        public string Chipset { get; set; } = null!;
        public int BandwidthMBytes { get; set; }

        public IReadOnlyList<string> Validate() => new Validation(this).Errors;
    }
}
