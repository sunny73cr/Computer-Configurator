namespace ComputerConfigurator.Api.MotherboardEthernetPort.DTO
{
    public class Validation
    {
        private readonly List<string> _errors = new();
        public IReadOnlyList<string> Errors { get => _errors.AsReadOnly(); }

        public Validation(DTO.Create MotherboardEthernetPort)
        {
            DomainValidation.Numeric.ValueRange(_errors, "Count", MotherboardEthernetPort.Count, 1, 4);
        }

        public Validation(DTO.Edit MotherboardEthernetPort)
        {
            DomainValidation.Numeric.ValueRange(_errors, "Count", MotherboardEthernetPort.Count, 1, 4);
        }
    }
}
