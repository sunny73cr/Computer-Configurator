namespace ComputerConfigurator.Api.MotherboardChipset.DTO
{
    public class Validation
    {
        private readonly List<string> _errors = new();

        public IReadOnlyList<string> Errors { get => _errors; }

        public Validation(Create MotherboardChipset)
        {
            DomainValidation.String.LengthRange(_errors, "Version", MotherboardChipset.Version, 1, 20);
        }
    }
}
