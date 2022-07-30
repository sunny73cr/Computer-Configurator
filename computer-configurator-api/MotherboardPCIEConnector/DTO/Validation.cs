namespace ComputerConfigurator.Api.MotherboardPCIEConnector.DTO
{
    public class Validation
    {
        private readonly List<string> _errors = new();
        public IReadOnlyList<string> Errors { get => _errors.AsReadOnly(); }

        public Validation(DTO.Create MotherboardPCIEConnector)
        {
            DomainValidation.Numeric.ValueRange(_errors, "Count", MotherboardPCIEConnector.Count, 1, 25);
        }

        public Validation(DTO.Edit MotherboardPCIEConnector)
        {
            DomainValidation.Numeric.ValueRange(_errors, "Count", MotherboardPCIEConnector.Count, 1, 25);
        }
    }
}
