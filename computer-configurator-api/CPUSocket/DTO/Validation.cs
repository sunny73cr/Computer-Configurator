namespace ComputerConfigurator.Api.CPUSocket.DTO
{
    public class Validation
    {
        private readonly List<string> _errors = new();

        public IReadOnlyList<string> Errors { get => _errors; }

        public Validation(DTO.Create cpusocket)
        {
            DomainValidation.String.LengthRange(_errors, "Version", cpusocket.Version, 1, 20);
        }

        public Validation(DTO.Edit cpusocket)
        {
            DomainValidation.Guid.NotEmpty(_errors, "UUID", cpusocket.UUID);
            DomainValidation.String.LengthRange(_errors, "Version", cpusocket.Version, 1, 20); 
        }
    }
}
