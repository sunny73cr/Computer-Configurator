namespace ComputerConfigurator.Api.FanHeader.DTO
{
    public class Create
    {
        public Guid UUID { get; set; } = Guid.NewGuid();
        public int PinCount { get; set; }

        public IReadOnlyList<string> Validate() => new Validation(this).Errors;
    }
}
