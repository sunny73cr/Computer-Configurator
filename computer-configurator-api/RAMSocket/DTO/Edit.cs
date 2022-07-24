namespace ComputerConfigurator.Api.RAMSocket.DTO
{
    public class Edit
    {
        public Guid UUID { get; set; } = Guid.Empty;
        public string Version { get; set; } = string.Empty;

        public IReadOnlyList<string> Validate() => new Validation(this).Errors;
    }
}
