namespace ComputerConfigurator.Api.MotherboardUSBPort.DTO
{
    public class Validation
    {
        private readonly List<string> _errors = new();
        public IReadOnlyList<string> Errors { get => _errors.AsReadOnly(); }

        public Validation(DTO.Create MotherboardUSBPort)
        {
            DomainValidation.Numeric.MaximumValue(_errors, "External Count", MotherboardUSBPort.ExternalCount, 16);
            DomainValidation.Numeric.MaximumValue(_errors, "Internal Count", MotherboardUSBPort.InternalCount, 16);
            if (MotherboardUSBPort.ExternalCount == 0 && MotherboardUSBPort.InternalCount == 0) _errors.Add("There must be at least one port.");
        }

        public Validation(DTO.Edit MotherboardUSBPort)
        {
            DomainValidation.Numeric.MaximumValue(_errors, "External Count", MotherboardUSBPort.ExternalCount, 16);
            DomainValidation.Numeric.MaximumValue(_errors, "Internal Count", MotherboardUSBPort.InternalCount, 16);
            if (MotherboardUSBPort.ExternalCount == 0 && MotherboardUSBPort.InternalCount == 0) _errors.Add("There must be at least one port.");
        }
    }
}
