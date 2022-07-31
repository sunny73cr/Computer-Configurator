namespace ComputerConfigurator.Api.GPU
{
    public class GPU : Part.Part
    {
        public Guid PCIEConnectorUUID { get; set; }
        public int VRAMMBytes { get; set; }
        public int BaseClockSpeed { get; set; }
        public int? BoostClockSpeed { get; set; }
        public int MaxDisplayCount { get; set; }
        public int LengthMM { get; set; }
        public int WidthMM { get; set; }
        public int HeightMM { get; set; }
        public float SlotWidth { get; set; }

        public virtual Part.Part Part { get; set; } = null!;
        public virtual PCIEConnector.PCIEConnector PCIEConnector { get; set; } = null!;
        public virtual List<GPUDisplayConnector.GPUDisplayConnector> DisplayConnectors { get; set; } = new();

        public GPU()
        {

        }

        public GPU(DTO.Create gpu) : base(gpu)
        {
            PCIEConnectorUUID = gpu.PCIEConnectorUUID;
            VRAMMBytes = gpu.VRAMMBytes;
            BaseClockSpeed = gpu.BaseClockSpeed;
            BoostClockSpeed = gpu.BoostClockSpeed;
            MaxDisplayCount = gpu.MaxDisplayCount;
            LengthMM = gpu.LengthMM;
            WidthMM = gpu.WidthMM;
            HeightMM = gpu.HeightMM;
            SlotWidth = gpu.SlotWidth;
            DisplayConnectors.AddRange(gpu.GPUDisplayConnectors.Select(
                createGPUDisplayConnector => new GPUDisplayConnector.GPUDisplayConnector(gpu.UUID, createGPUDisplayConnector)
            ));
        }

        public static void Edit(GPU gpu, DTO.Edit edits)
        {
            Api.Part.Part.Edit(gpu, edits);

            if (gpu.PCIEConnectorUUID != edits.PCIEConnectorUUID) gpu.PCIEConnectorUUID = edits.PCIEConnectorUUID;
            if (gpu.VRAMMBytes != edits.VRAMMBytes) gpu.VRAMMBytes = edits.VRAMMBytes;
            if (gpu.BaseClockSpeed != edits.BaseClockSpeed) gpu.BaseClockSpeed = edits.BaseClockSpeed;
            if (gpu.BoostClockSpeed != edits.BoostClockSpeed) gpu.BoostClockSpeed = edits.BoostClockSpeed;
            if (gpu.MaxDisplayCount != edits.MaxDisplayCount) gpu.MaxDisplayCount = edits.MaxDisplayCount;
            if (gpu.LengthMM != edits.LengthMM) gpu.LengthMM = edits.LengthMM;
            if (gpu.WidthMM != edits.WidthMM) gpu.WidthMM = edits.WidthMM;
            if (gpu.HeightMM != edits.HeightMM) gpu.HeightMM = edits.HeightMM;
            if (gpu.SlotWidth != edits.SlotWidth) gpu.SlotWidth = edits.SlotWidth;
        }
    }
}
