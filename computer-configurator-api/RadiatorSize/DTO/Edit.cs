namespace ComputerConfigurator.Api.RadiatorSize.DTO
{
    public class Edit
    {
        public Guid UUID { get; set; } = Guid.Empty;
        public int Size { get; set; }

        public IReadOnlyList<string> Validate() => new Validation(this).Errors;
    }
}
