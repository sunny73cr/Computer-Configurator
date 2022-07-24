namespace ComputerConfigurator.Api.AudioPort.DTO
{
    public class Create
    {
        public Guid UUID { get; set; } = Guid.NewGuid();
        public int PinCount { get; set; }
        public int ConnectorSize { get; set; }

        public IReadOnlyList<string> Validate() => new Validation(this).Errors;
    }
}
