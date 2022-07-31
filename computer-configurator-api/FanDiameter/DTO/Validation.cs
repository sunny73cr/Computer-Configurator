namespace ComputerConfigurator.Api.FanDiameter.DTO
{
    public class Validation
    {
        private readonly List<string> _errors = new();

        public IReadOnlyList<string> Errors { get => _errors; }

        public Validation(Create FanDiameter)
        {
            DomainValidation.Numeric.ValueRange(_errors, "Diameter", FanDiameter.Diameter, 1, 50);
        }
    }
}
