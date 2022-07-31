namespace ComputerConfigurator.Api.RAMSpeed.DTO
{
    public class Validation
    {
        private readonly List<string> _errors = new();

        public IReadOnlyList<string> Errors { get => _errors; }

        public Validation(Create RAMSpeed)
        {
            DomainValidation.Numeric.ValueRange(_errors, "ClockRate", RAMSpeed.ClockRate, 800, 14000);
        }
    }
}
