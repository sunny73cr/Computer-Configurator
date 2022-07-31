namespace ComputerConfigurator.Api.RAM.DTO
{
    public class Validation
    {
        private readonly List<string> _errors = new();
        public IReadOnlyList<string> Errors { get => _errors.AsReadOnly(); }

        public Validation(DTO.Create ram)
        {
            _errors.AddRange(new Part.DTO.Validation(ram).Errors);

            DomainValidation.Numeric.ValueRange(_errors, "Module capacity", ram.ModuleCapacityGBytes, 1, 512);
            DomainValidation.Numeric.ValueRange(_errors, "DIMM count", ram.DIMMCount, 1, 32);
            DomainValidation.Numeric.ValueRange(_errors, "CAS", ram.CAS, 10, 50);
            DomainValidation.Numeric.ValueRange(_errors, "TRCD", ram.TRCD, 10, 55);
            DomainValidation.Numeric.ValueRange(_errors, "TRP", ram.TRP, 10, 55);
            DomainValidation.Numeric.ValueRange(_errors, "TRAS", ram.TRAS, 15, 100);
        }

        public Validation(DTO.Edit ram)
        {
            _errors.AddRange(new Part.DTO.Validation(ram).Errors);

            DomainValidation.Numeric.ValueRange(_errors, "Module capacity", ram.ModuleCapacityGBytes, 1, 512);
            DomainValidation.Numeric.ValueRange(_errors, "DIMM count", ram.DIMMCount, 1, 32);
            DomainValidation.Numeric.ValueRange(_errors, "CAS", ram.CAS, 10, 50);
            DomainValidation.Numeric.ValueRange(_errors, "TRCD", ram.TRCD, 10, 55);
            DomainValidation.Numeric.ValueRange(_errors, "TRP", ram.TRP, 10, 55);
            DomainValidation.Numeric.ValueRange(_errors, "TRAS", ram.TRAS, 15, 100);
        }
    }
}
