namespace ComputerConfigurator.Api.MotherboardPCIEConnector.DTO
{
    public class Details
    {
        public PCIEConnector.DTO.Details PCIEConnector { get; set; }
        public int Count { get; set; }

        public Details(MotherboardPCIEConnector MotherboardPCIEConnector)
        {
            PCIEConnector = new PCIEConnector.DTO.Details(MotherboardPCIEConnector.PCIEConnector);
            Count = MotherboardPCIEConnector.Count;
        }
    }
}
