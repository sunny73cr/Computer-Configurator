namespace ComputerConfigurator.Api.ChassisRadiatorSupport.DTO
{
    public class Validation
    {
        private readonly List<string> _errors = new();
        public IReadOnlyList<string> Errors { get => _errors.AsReadOnly(); }

        public Validation(DTO.Create ChassisRadiatorSupport)
        {
            DomainValidation.Numeric.ValueRange(_errors, "Maximum width", ChassisRadiatorSupport.MaximumWidthMM, 20, 60);
        }
    }
}
