namespace ComputerConfigurator.Api.CPUSocket.DTO
{
    public class Create
    {
        public Guid UUID { get; } = Guid.NewGuid();
        public string Version { get; set; } = string.Empty;

        public Create()
        {

        }

        public IReadOnlyList<string> Validate() => new Validation(this).Errors;
    }
}
