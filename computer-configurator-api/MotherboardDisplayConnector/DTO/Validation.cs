namespace ComputerConfigurator.Api.MotherboardDisplayConnector.DTO
{
    public class Validation
    {
        private readonly List<string> _errors = new();
        public IReadOnlyList<string> Errors { get => _errors.AsReadOnly(); }

        public Validation(DTO.Create MotherboardDisplayConnector)
        {
            DomainValidation.Numeric.ValueRange(_errors, "Count", MotherboardDisplayConnector.Count, 1, 4);
        }

        public Validation(DTO.Edit MotherboardDisplayConnector)
        {
            DomainValidation.Numeric.ValueRange(_errors, "Count", MotherboardDisplayConnector.Count, 1, 4);
        }
    }
}
