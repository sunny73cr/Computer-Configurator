namespace ComputerConfigurator.Api.FanHeader.DTO
{
    public class Validation
    {
        private readonly List<string> _errors = new();

        public IReadOnlyList<string> Errors { get => _errors; }

        public Validation(Create FanHeader)
        {
            DomainValidation.Numeric.ValueRange(_errors, "Diameter", FanHeader.PinCount, 3, 4);
        }
    }
}
