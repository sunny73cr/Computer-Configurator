namespace ComputerConfigurator.Api.CPUHeatsink.DTO
{
    public class Validation
    {
        private readonly List<string> _errors = new();
        public IReadOnlyList<string> Errors { get => _errors.AsReadOnly(); }

        public Validation(DTO.Create cpuheatsink)
        {
            _errors.AddRange(new CPUCooler.DTO.Validation(cpuheatsink).Errors);

            DomainValidation.Numeric.ValueRange(_errors, "Height", cpuheatsink.HeightMM, 1, 200);
        }

        public Validation(DTO.Edit cpuheatsink)
        {
            _errors.AddRange(new CPUCooler.DTO.Validation(cpuheatsink).Errors);

            DomainValidation.Numeric.ValueRange(_errors, "Height", cpuheatsink.HeightMM, 1, 200);
        }
    }
}
