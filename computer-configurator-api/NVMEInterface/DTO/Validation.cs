namespace ComputerConfigurator.Api.NVMEInterface.DTO
{
    public class Validation
    {
        private readonly List<string> _errors = new();

        public IReadOnlyList<string> Errors { get => _errors; }

        public Validation(Create NVMEInterface)
        {
            DomainValidation.String.LengthRange(_errors, "Interface", NVMEInterface.Interface, 1, 10);
        }
    }
}
