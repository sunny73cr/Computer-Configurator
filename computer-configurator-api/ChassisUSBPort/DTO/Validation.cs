namespace ComputerConfigurator.Api.ChassisUSBPort.DTO
{
    public class Validation
    {
        private readonly List<string> _errors = new();
        public IReadOnlyList<string> Errors { get => _errors.AsReadOnly(); }

        public Validation(DTO.Create ChassisUSBPort)
        {
            DomainValidation.Numeric.ValueRange(_errors, "Count", ChassisUSBPort.Count, 1, 20);
        }

        public Validation(DTO.Edit ChassisUSBPort)
        {
            DomainValidation.Numeric.ValueRange(_errors, "Count", ChassisUSBPort.Count, 1, 20);
        }
    }
}
