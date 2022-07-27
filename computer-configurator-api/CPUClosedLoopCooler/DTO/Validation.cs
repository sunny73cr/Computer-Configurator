namespace ComputerConfigurator.Api.CPUClosedLoopCooler.DTO
{
    public class Validation
    {
        private readonly List<string> _errors = new();
        public IReadOnlyList<string> Errors { get => _errors.AsReadOnly(); }

        public Validation(DTO.Create cpucooler)
        {
            _errors.AddRange(new CPUCooler.DTO.Validation(cpucooler).Errors);
        }

        public Validation(DTO.Edit cpucooler)
        {
            _errors.AddRange(new CPUCooler.DTO.Validation(cpucooler).Errors);
        }
    }
}
