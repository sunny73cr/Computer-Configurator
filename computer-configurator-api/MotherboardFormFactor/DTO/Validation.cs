namespace ComputerConfigurator.Api.MotherboardFormFactor.DTO
{
    public class Validation
    {
        private readonly List<string> _errors = new();

        public IReadOnlyList<string> Errors { get => _errors; }

        public Validation(Create MotherboardFormFactor)
        {
            DomainValidation.String.LengthRange(_errors, "Form factor", MotherboardFormFactor.FormFactor, 1, 30);
        }

        public Validation(Edit MotherboardFormFactor)
        {
            DomainValidation.String.LengthRange(_errors, "Form factor", MotherboardFormFactor.FormFactor, 1, 30);
        }
    }
}
