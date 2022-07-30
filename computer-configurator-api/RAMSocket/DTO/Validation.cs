namespace ComputerConfigurator.Api.RAMSocket.DTO
{
    public class Validation
    {
        private readonly List<string> _errors = new();

        public IReadOnlyList<string> Errors { get => _errors; }

        public Validation(Create RAMSocket)
        {
            DomainValidation.String.LengthRange(_errors, "Version", RAMSocket.Version, 1, 15);
        }
    }
}
