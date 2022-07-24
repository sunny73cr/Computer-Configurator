namespace ComputerConfigurator.Api.RadiatorSize.DTO
{
    public class Validation
    {
        private readonly List<string> _errors = new();

        public IReadOnlyList<string> Errors { get => _errors; }

        public Validation(Create RadiatorSize)
        {
            DomainValidation.Numeric.ValueRange(_errors, "Size", RadiatorSize.Size, 120, 1080);
        }

        public Validation(Edit RadiatorSize)
        {
            DomainValidation.Numeric.ValueRange(_errors, "Size", RadiatorSize.Size, 120, 1080);
        }
    }
}
