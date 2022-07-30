namespace ComputerConfigurator.Api.RAIDMode.DTO
{
    public class Validation
    {
        private readonly List<string> _errors = new();

        public IReadOnlyList<string> Errors { get => _errors; }

        public Validation(Create RAIDMode)
        {
            DomainValidation.String.LengthRange(_errors, "Mode", RAIDMode.Mode, 1, 50);
        }
    }
}
