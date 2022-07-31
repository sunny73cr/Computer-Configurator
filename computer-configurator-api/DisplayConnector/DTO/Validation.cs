namespace ComputerConfigurator.Api.DisplayConnector.DTO
{
    public class Validation
    {
        private readonly List<string> _errors = new();

        public IReadOnlyList<string> Errors { get => _errors; }

        public Validation(Create DisplayConnector)
        {
            DomainValidation.String.LengthRange(_errors, "Interface", DisplayConnector.Interface, 1, 15);
            DomainValidation.String.LengthRange(_errors, "Version", DisplayConnector.Version, 1, 15);
        }
    }
}
