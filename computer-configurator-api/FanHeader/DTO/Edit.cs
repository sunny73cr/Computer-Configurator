namespace ComputerConfigurator.Api.FanHeader.DTO
{
    public class Edit
    {
        public Guid UUID { get; set; } = Guid.Empty;
        public int PinCount { get; set; }

        public IReadOnlyList<string> Validate() => new Validation(this).Errors;
    }
}
