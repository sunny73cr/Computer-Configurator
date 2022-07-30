namespace ComputerConfigurator.Api.MotherboardRAMSocket.DTO
{
    public class Validation
    {
        private readonly List<string> _errors = new();
        public IReadOnlyList<string> Errors { get => _errors.AsReadOnly(); }

        public Validation(DTO.Create MotherboardRAMSocket)
        {
            DomainValidation.Numeric.ValueRange(_errors, "Count", MotherboardRAMSocket.Count, 1, 16);
        }

        public Validation(DTO.Edit MotherboardRAMSocket)
        {
            DomainValidation.Numeric.ValueRange(_errors, "Count", MotherboardRAMSocket.Count, 1, 16);
        }
    }
}
