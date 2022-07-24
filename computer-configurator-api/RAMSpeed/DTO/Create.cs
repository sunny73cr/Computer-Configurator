namespace ComputerConfigurator.Api.RAMSpeed.DTO
{
    public class Create
    {
        public Guid UUID { get; set; } = Guid.NewGuid();
        public int ClockRate { get; set; }

        public IReadOnlyList<string> Validate() => new Validation(this).Errors;
    }
}
