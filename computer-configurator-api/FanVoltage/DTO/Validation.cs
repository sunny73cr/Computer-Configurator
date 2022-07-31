namespace ComputerConfigurator.Api.FanVoltage.DTO
{
    public class Validation
    {
        private readonly List<string> _errors = new();

        public IReadOnlyList<string> Errors { get => _errors; }

        public Validation(Create FanVoltage)
        {
            DomainValidation.Numeric.ValueRange(_errors, "Voltage", FanVoltage.Voltage, 3, 48);
        }
    }
}
