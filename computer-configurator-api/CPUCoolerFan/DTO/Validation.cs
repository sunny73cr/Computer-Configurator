namespace ComputerConfigurator.Api.CPUCoolerFan.DTO
{
    public class Validation
    {
        private readonly List<string> _errors = new();
        public IReadOnlyList<string> Errors { get => _errors.AsReadOnly(); }

        public Validation(DTO.Create cpucoolerfan)
        {
            DomainValidation.Numeric.ValueRange(_errors, "Count", cpucoolerfan.Count, 1, 8);
        }

        public Validation(DTO.Edit cpucoolerfan)
        {
            DomainValidation.Numeric.ValueRange(_errors, "Count", cpucoolerfan.Count, 1, 8);
        }
    }
}
