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

        public static void Edit(BenchmarkedResolution benchmarkedResolution, DTO.Edit edits)
        {
            if (benchmarkedResolution.PixelWidth != edits.PixelWidth) benchmarkedResolution.PixelWidth = edits.PixelWidth;
            if (benchmarkedResolution.PixelHeight != edits.PixelHeight) benchmarkedResolution.PixelHeight = edits.PixelHeight;
        }
    }
}
