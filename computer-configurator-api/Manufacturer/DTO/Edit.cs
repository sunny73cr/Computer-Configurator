namespace ComputerConfigurator.Api.Manufacturer.DTO
{
    public class Edit
    {
        public Guid UUID { get; set; }
        public string Name { get; set; } = string.Empty;

        public IReadOnlyList<string> Valdiate() => new Validation(this).Errors;
    }
}
