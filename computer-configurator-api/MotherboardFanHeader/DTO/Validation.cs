namespace ComputerConfigurator.Api.MotherboardFanHeader.DTO
{
    public class Validation
    {
        private readonly List<string> _errors = new();
        public IReadOnlyList<string> Errors { get => _errors.AsReadOnly(); }

        public Validation(DTO.Create MotherboardFanHeader)
        {
            DomainValidation.Numeric.ValueRange(_errors, "Count", MotherboardFanHeader.Count, 1, 4);
        }

        public Validation(DTO.Edit MotherboardFanHeader)
        {
            DomainValidation.Numeric.ValueRange(_errors, "Count", MotherboardFanHeader.Count, 1, 4);
        }
    }
}
