namespace ComputerConfigurator.Api.DisplayConnector.DTO
{
    public class Edit
    {
        public Guid UUID { get; set; } = Guid.Empty;
        public string Interface { get; set; } = null!;
        public string Version { get; set; } = null!;

        public IReadOnlyList<string> Validate() => new Validation(this).Errors;
    }
}
