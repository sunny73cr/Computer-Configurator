namespace ComputerConfigurator.Api.BenchmarkedResolution.DTO
{
    public class Create
    {
        public Guid UUID { get; set; } = Guid.NewGuid();
        public int PixelWidth { get; set; }
        public int PixelHeight { get; set; }

        public IReadOnlyList<string> Validate() => new Validation(this).Errors;
    }
}
