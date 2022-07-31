namespace ComputerConfigurator.Api.AudioPort.DTO
{
    public class Validation
    {
        private readonly List<string> _errors = new();

        public IReadOnlyList<string> Errors { get => _errors; }

        public Validation(Create audioPort)
        {
            DomainValidation.Numeric.ValueRange(_errors, "Pin count", audioPort.PinCount, 1, 15360);
            DomainValidation.Numeric.ValueRange(_errors, "Connector size", audioPort.ConnectorSize, 1, 8640);
        }
    }
}
