namespace ComputerConfigurator.Api.Account.DTO
{
    public class Edit
    {
        public Guid UUID { get; set; }
        public string Email { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public IReadOnlyList<string> Validate() => new Validation(this).Errors;
    }
}
