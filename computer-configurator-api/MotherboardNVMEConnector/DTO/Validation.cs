namespace ComputerConfigurator.Api.MotherboardNVMEConnector.DTO
{
    public class Validation
    {
        private readonly List<string> _errors = new();
        public IReadOnlyList<string> Errors { get => _errors.AsReadOnly(); }

        public Validation(DTO.Create MotherboardNVMEConnector)
        {
            DomainValidation.Numeric.ValueRange(_errors, "Count", MotherboardNVMEConnector.Count, 1, 8);
        }

        public Validation(DTO.Edit MotherboardNVMEConnector)
        {
            DomainValidation.Numeric.ValueRange(_errors, "Count", MotherboardNVMEConnector.Count, 1, 8);
        }
    }
}
