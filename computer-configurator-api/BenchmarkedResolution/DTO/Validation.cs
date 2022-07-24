namespace ComputerConfigurator.Api.BenchmarkedResolution.DTO
{
    public class Validation
    {
        private readonly List<string> _errors = new();

        public IReadOnlyList<string> Errors { get => _errors; }

        public Validation(Create benchmarkedResolution)
        {
            DomainValidation.Numeric.ValueRange(_errors, "Pixel width", benchmarkedResolution.PixelWidth, 1, 15360);
            DomainValidation.Numeric.ValueRange(_errors, "Pixel height", benchmarkedResolution.PixelHeight, 1, 8640);
        }

        public Validation(Edit benchmarkedResolution)
        {
            DomainValidation.Numeric.ValueRange(_errors, "Pixel width", benchmarkedResolution.PixelWidth, 1, 15360);
            DomainValidation.Numeric.ValueRange(_errors, "Pixel height", benchmarkedResolution.PixelHeight, 1, 8640);
        }
    }
}
