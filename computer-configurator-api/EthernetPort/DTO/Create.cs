namespace ComputerConfigurator.Api.EthernetPort.DTO
{
    public class Create
    {
        public Guid UUID { get; set; } = Guid.NewGuid();
        public string Chipset { get; set; } = null!;
        public int BandwidthMBytes { get; set; }

        public IReadOnlyList<string> Validate() => new Validation(this).Errors;
    }
}
