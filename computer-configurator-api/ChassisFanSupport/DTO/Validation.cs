namespace ComputerConfigurator.Api.ChassisFanSupport.DTO
{
    public class Validation
    {
        private readonly List<string> _errors = new();
        public IReadOnlyList<string> Errors { get => _errors.AsReadOnly(); }

        public Validation(DTO.Create ChassisFanSupport)
        {
            DomainValidation.Numeric.ValueRange(_errors, "Maximum width", ChassisFanSupport.MaximumWidthMM, 10, 30);
            DomainValidation.Numeric.ValueRange(_errors, "Count", ChassisFanSupport.Count, 1, 5);
        }
    }
}
