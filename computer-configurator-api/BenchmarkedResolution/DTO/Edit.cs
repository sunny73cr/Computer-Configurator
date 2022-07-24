namespace ComputerConfigurator.Api.BenchmarkedResolution.DTO
{
    public class Edit
    {
        public Guid UUID { get; set; } = Guid.Empty;
        public int PixelWidth { get; set; }
        public int PixelHeight { get; set; }

        public IReadOnlyList<string> Validate() => new Validation(this).Errors;
    }
}
