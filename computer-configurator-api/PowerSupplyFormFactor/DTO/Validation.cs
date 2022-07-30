namespace ComputerConfigurator.Api.PowerSupplyFormFactor.DTO
{
    public class Validation
    {
        private readonly List<string> _errors = new();

        public IReadOnlyList<string> Errors { get => _errors; }

        public Validation(Create PowerSupplyFormFactor)
        {
            DomainValidation.String.LengthRange(_errors, "Form factor", PowerSupplyFormFactor.FormFactor, 1, 10);
        }
    }
}
