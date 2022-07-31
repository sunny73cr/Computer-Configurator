namespace ComputerConfigurator.Api.NVMEFormFactor.DTO
{
    public class Validation
    {
        private readonly List<string> _errors = new();

        public IReadOnlyList<string> Errors { get => _errors; }

        public Validation(Create NVMEFormFactor)
        {
            DomainValidation.String.LengthRange(_errors, "Form factor", NVMEFormFactor.FormFactor, 1, 15);
        }
    }
}
