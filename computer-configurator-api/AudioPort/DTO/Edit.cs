namespace ComputerConfigurator.Api.AudioPort.DTO
{
    public class Edit
    {
        public Guid UUID { get; set; } = Guid.Empty;
        public int PinCount { get; set; }
        public int ConnectorSize { get; set; }

        public IReadOnlyList<string> Validate() => new Validation(this).Errors;
    }
}
