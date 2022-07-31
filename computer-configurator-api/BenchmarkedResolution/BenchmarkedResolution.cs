namespace ComputerConfigurator.Api.BenchmarkedResolution
{
    public partial class BenchmarkedResolution
    {
        public Guid UUID { get; set; }
        public int PixelWidth { get; set; }
        public int PixelHeight { get; set; }

        public BenchmarkedResolution()
        {

        }

        public BenchmarkedResolution(DTO.Create benchmarkedresolution)
        {
            UUID = benchmarkedresolution.UUID;
            PixelWidth = benchmarkedresolution.PixelWidth;
            PixelHeight = benchmarkedresolution.PixelHeight;
        }
    }
}
