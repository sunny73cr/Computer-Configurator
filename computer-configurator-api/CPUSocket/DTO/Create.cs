namespace ComputerConfigurator.Api.CPUSocket.DTO
{
    public class Create
    {
        public Guid UUID { get; } = Guid.NewGuid();
        public string Version { get; set; } = null!;

        public Create()
        {

        }

        public IReadOnlyList<string> Validate() => new Validation(this).Errors;
    }
}
