namespace ComputerConfigurator.Api.RAMSpeed.DTO
{
    public class Edit
    {
        public Guid UUID { get; set; } = Guid.Empty;
        public int ClockRate { get; set; }

        public IReadOnlyList<string> Validate() => new Validation(this).Errors;
    }
}
