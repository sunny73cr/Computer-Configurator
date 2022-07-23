namespace ComputerConfigurator.Api.Account.DTO
{
    public class Create
    {
        public Guid UUID { get; } = Guid.NewGuid();
        public string Email { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string Salt { get; set; } = string.Empty;
        public DateTime TimestampCreated { get; } = DateTime.UtcNow;

        public IReadOnlyList<string> Validate() => new Validation(this).Errors;
    }
}