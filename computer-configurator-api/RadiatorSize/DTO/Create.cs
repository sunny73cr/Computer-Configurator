namespace ComputerConfigurator.Api.RadiatorSize.DTO
{
    public class Create
    {
        public Guid UUID { get; set; } = Guid.NewGuid();
        public int Size { get; set; }

        public IReadOnlyList<string> Validate() => new Validation(this).Errors;
    }
}
