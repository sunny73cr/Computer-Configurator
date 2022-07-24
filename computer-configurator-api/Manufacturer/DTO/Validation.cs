namespace ComputerConfigurator.Api.Manufacturer.DTO
{
    public class Validation
    {
        private readonly List<string> _errors = new();

        public IReadOnlyList<string> Errors { get => _errors.AsReadOnly(); }

        public Validation(DTO.Create manufacturer)
        {
            DomainValidation.String.LengthRange(_errors, "Name", manufacturer.Name, 1, 50);
        }

        public Validation(DTO.Edit manufacturer)
        {
            DomainValidation.String.LengthRange(_errors, "Name", manufacturer.Name, 1, 50);
        }
    }
}
