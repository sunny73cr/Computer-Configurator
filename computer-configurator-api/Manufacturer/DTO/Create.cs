namespace ComputerConfigurator.Api.Manufacturer.DTO
{
    public class Create
    {
        public Guid UUID { get; } = Guid.NewGuid();
        public string Name { get; set; } = string.Empty;

        public IReadOnlyList<string> Valdiate() => new Validation(this).Errors;
    }
}
