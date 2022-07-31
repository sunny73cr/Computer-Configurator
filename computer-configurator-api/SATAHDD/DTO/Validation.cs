namespace ComputerConfigurator.Api.SATAHDD.DTO
{
    public class Validation
    {
        private readonly List<string> _errors = new();

        public IReadOnlyList<string> Errors { get => _errors.AsReadOnly(); }

        public Validation(DTO.Create sataHDD)
        {
            _errors.AddRange(new Storage.DTO.Validation(sataHDD).Errors);

            DomainValidation.Numeric.ValueRange(_errors, "Spindle RPM", sataHDD.SpindleRPM, 1, 30000);
        }

        public Validation(DTO.Edit sataHDD)
        {
            _errors.AddRange(new Storage.DTO.Validation(sataHDD).Errors);

            DomainValidation.Numeric.ValueRange(_errors, "Spindle RPM", sataHDD.SpindleRPM, 1, 30000);
        }
    }
}
