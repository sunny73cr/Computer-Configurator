namespace ComputerConfigurator.Api.ChassisPowerSupplyFormFactorSupport.DTO
{
    public class Validation
    {
        private readonly List<string> _errors = new();
        public IReadOnlyList<string> Errors { get => _errors.AsReadOnly(); }

        public Validation(DTO.Create ChassisPowerSupplyFormFactorSupport)
        {
        }

        public Validation(DTO.Edit ChassisPowerSupplyFormFactorSupport)
        {
        }
    }
}
