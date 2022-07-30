namespace ComputerConfigurator.Api.Motherboard.DTO
{
    public class Validation
    {
        private readonly List<string> _errors = new();
        public IReadOnlyList<string> Errors { get => _errors.AsReadOnly(); }

        public Validation(DTO.Create motherboard)
        {
            DomainValidation.Numeric.ValueRange(_errors, "Max RAM Capacity", motherboard.MaxRAMCapacityMByte, 1, 16384000);
            DomainValidation.Numeric.ValueRange(_errors, "CPU Socket Count", motherboard.CPUSocketCount, 1, 4);
        }

        public Validation(DTO.Edit motherboard)
        {
            DomainValidation.Numeric.ValueRange(_errors, "Max RAM Capacity", motherboard.MaxRAMCapacityMByte, 1, 16384000);
            DomainValidation.Numeric.ValueRange(_errors, "CPU Socket Count", motherboard.CPUSocketCount, 1, 4);
        }
    }
}
