namespace ComputerConfigurator.Api.RAIDMode.DTO
{
    public class Edit
    {
        public Guid UUID { get; set; } = Guid.Empty;
        public string Mode { get; set; } = string.Empty;

        public IReadOnlyList<string> Validate() => new Validation(this).Errors;
    }
}
