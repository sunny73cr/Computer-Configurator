namespace ComputerConfigurator.Api.CPUSocket.DTO
{
    public class Edit
    {
        public Guid UUID { get; set; }
        public string Version { get; set; } = null!;

        public Edit()
        {

        }

        public IReadOnlyList<string> Validate() => new Validation(this).Errors;
    }
}
