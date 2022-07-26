namespace ComputerConfigurator.Api.FanVoltage.DTO
{
    public class Edit
    {
        public Guid UUID { get; set; } = Guid.Empty;
        public float Voltage { get; set; }

        public IReadOnlyList<string> Validate() => new Validation(this).Errors;
    }
}
