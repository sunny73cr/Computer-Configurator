namespace ComputerConfigurator.Api.MotherboardRAMSpeed.DTO
{
    public class Validation
    {
        private readonly List<string> _errors = new();
        public IReadOnlyList<string> Errors { get => _errors.AsReadOnly(); }

        public Validation(DTO.Create MotherboardRAMSpeed)
        {
        }

        public Validation(DTO.Edit MotherboardRAMSpeed)
        {
        }
    }
}
