namespace ComputerConfigurator.Api.RAIDMode.DTO
{
    public class Create
    {
        public Guid UUID { get; set; } = Guid.NewGuid();
        public string Mode { get; set; } = string.Empty;

        public IReadOnlyList<string> Validate() => new Validation(this).Errors;
    }
}
