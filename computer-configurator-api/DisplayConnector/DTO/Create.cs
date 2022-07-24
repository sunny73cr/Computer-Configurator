namespace ComputerConfigurator.Api.DisplayConnector.DTO
{
    public class Create
    {
        public Guid UUID { get; set; } = Guid.NewGuid();
        public string Interface { get; set; } = null!;
        public string Version { get; set; } = null!;

        public IReadOnlyList<string> Validate() => new Validation(this).Errors;
    }
}
