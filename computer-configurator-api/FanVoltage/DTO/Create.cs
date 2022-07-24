namespace ComputerConfigurator.Api.FanVoltage.DTO
{
    public class Create
    {
        public Guid UUID { get; set; } = Guid.NewGuid();
        public int Voltage { get; set; }

        public IReadOnlyList<string> Validate() => new Validation(this).Errors;
    }
}
