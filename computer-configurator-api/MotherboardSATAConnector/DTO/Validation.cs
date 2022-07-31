namespace ComputerConfigurator.Api.MotherboardSATAConnector.DTO
{
    public class Validation
    {
        private readonly List<string> _errors = new();
        public IReadOnlyList<string> Errors { get => _errors.AsReadOnly(); }

        public Validation(DTO.Create MotherboardSATAConnector)
        {
            DomainValidation.Numeric.ValueRange(_errors, "Count", MotherboardSATAConnector.Count, 1, 16);
        }

        public Validation(DTO.Edit MotherboardSATAConnector)
        {
            DomainValidation.Numeric.ValueRange(_errors, "Count", MotherboardSATAConnector.Count, 1, 16);
        }
    }
}
