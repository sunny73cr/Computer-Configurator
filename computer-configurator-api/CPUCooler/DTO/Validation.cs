namespace ComputerConfigurator.Api.CPUCooler.DTO
{
    public class Validation
    {
        private readonly List<string> _errors = new();
        public IReadOnlyList<string> Errors { get => _errors.AsReadOnly(); }

        public Validation(DTO.Create cpucooler)
        {
            _errors.AddRange(new Part.DTO.Validation(cpucooler).Errors);

            DomainValidation.Numeric.ValueRange(_errors, "TDP Rating", cpucooler.TDPRating, 1, 1000);
        }

        public Validation(DTO.Edit cpucooler)
        {
            _errors.AddRange(new Part.DTO.Validation(cpucooler).Errors);

            DomainValidation.Numeric.ValueRange(_errors, "TDP Rating", cpucooler.TDPRating, 1, 1000);
        }
    }
}
