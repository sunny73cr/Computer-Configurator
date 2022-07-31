namespace ComputerConfigurator.Api.NVMESSD.DTO
{
    public class Validation
    {
        private readonly List<string> _errors = new();

        public IReadOnlyList<string> Errors { get => _errors.AsReadOnly(); }

        public Validation(DTO.Create nvmessd)
        {
            _errors.AddRange(new Storage.DTO.Validation(nvmessd).Errors);
        }

        public Validation(DTO.Edit nvmessd)
        {
            _errors.AddRange(new Storage.DTO.Validation(nvmessd).Errors);
        }
    }
}
