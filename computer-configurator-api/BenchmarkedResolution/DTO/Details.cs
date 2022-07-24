namespace ComputerConfigurator.Api.BenchmarkedResolution.DTO
{
    public class Details
    {
        public Guid UUID { get; set; }
        public int PixelWidth { get; set; }
        public int PixelHeight { get; set; }

        public Details()
        {

        }

        public Details(BenchmarkedResolution benchmarkedResolution)
        {
            UUID = benchmarkedResolution.UUID;
            PixelWidth = benchmarkedResolution.PixelWidth;
            PixelHeight = benchmarkedResolution.PixelHeight;
        }
    }
}
