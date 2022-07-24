namespace ComputerConfigurator.Api.USBPort.DTO
{
    public class Validation
    {
        private readonly List<string> _errors = new();

        public IReadOnlyList<string> Errors { get => _errors; }

        public Validation(Create USBPort)
        {
            DomainValidation.String.LengthRange(_errors, "Interface", USBPort.Interface, 1, 15);
            DomainValidation.String.LengthRange(_errors, "Version", USBPort.Version, 1, 15);
        }

        public Validation(Edit USBPort)
        {
            DomainValidation.String.LengthRange(_errors, "Interface", USBPort.Interface, 1, 15);
            DomainValidation.String.LengthRange(_errors, "Version", USBPort.Version, 1, 15);
        }
    }
}
