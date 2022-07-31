namespace ComputerConfigurator.Api.SATASSD.DTO
{
    public class Validation
    {
        private readonly List<string> _errors = new();

        public IReadOnlyList<string> Errors { get => _errors.AsReadOnly(); }

        public Validation(DTO.Create sataSSD)
        {
            _errors.AddRange(new Storage.DTO.Validation(sataSSD).Errors);
        }

        public Validation(DTO.Edit sataSSD)
        {
            _errors.AddRange(new Storage.DTO.Validation(sataSSD).Errors);
        }
    }
}
