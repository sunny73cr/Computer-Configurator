namespace ComputerConfigurator.Api.PCIEConnector.DTO
{
    public class Details
    {
        public Guid UUID { get; set; }
        public PCIEGeneration.DTO.Details PCIEGeneration { get; set; } = null!;
        public int LaneCount { get; set; }

        public Details()
        {

        }

        public Details(PCIEConnector PCIEConnector)
        {
            UUID = PCIEConnector.UUID;
            PCIEGeneration = new PCIEGeneration.DTO.Details(PCIEConnector.PCIEGeneration);
            LaneCount = PCIEConnector.LaneCount;
        }
    }
}
