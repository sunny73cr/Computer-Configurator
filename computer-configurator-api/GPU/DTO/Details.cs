namespace ComputerConfigurator.Api.GPU.DTO
{
    public class Details : Part.DTO.Details
    {
        public PCIEConnector.DTO.Details PCIEConnector { get; set; }
        public int VRAMMBytes { get; set; }
        public int BaseClockSpeed { get; set; }
        public int? BoostClockSpeed { get; set; }
        public int MaxDisplayCount { get; set; }
        public int LengthMM { get; set; }
        public int WidthMM { get; set; }
        public int HeightMM { get; set; }
        public float SlotWidth { get; set; }
        public List<GPUDisplayConnector.DTO.Details> GPUDisplayConnectors { get; set; } = new();

        public Details(GPU gpu)
        {
            PCIEConnector = new PCIEConnector.DTO.Details(gpu.PCIEConnector);
            VRAMMBytes = gpu.VRAMMBytes;
            BaseClockSpeed = gpu.BaseClockSpeed;
            BoostClockSpeed = gpu.BoostClockSpeed;
            MaxDisplayCount = gpu.MaxDisplayCount;
            LengthMM = gpu.LengthMM;
            WidthMM = gpu.WidthMM;
            HeightMM = gpu.HeightMM;
            SlotWidth = gpu.SlotWidth;
            GPUDisplayConnectors.AddRange(gpu.DisplayConnectors.Select(
                gpuDisplayConnector => new GPUDisplayConnector.DTO.Details(gpuDisplayConnector)
            ));
        }
    }
}
