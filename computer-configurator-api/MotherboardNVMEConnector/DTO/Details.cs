namespace ComputerConfigurator.Api.MotherboardNVMEConnector.DTO
{
    public class Details
    {
        public PCIEGeneration.DTO.Details PCIEGeneration { get; set; }
        public NVMEInterface.DTO.Details NVMEInterface { get; set; }
        public NVMEFormFactor.DTO.Details NVMEFormFactor { get; set; }
        public int Count { get; set; }

        public Details(MotherboardNVMEConnector MotherboardNVMEConnector)
        {
            PCIEGeneration = new PCIEGeneration.DTO.Details(MotherboardNVMEConnector.PCIEGeneration);
            NVMEInterface = new NVMEInterface.DTO.Details(MotherboardNVMEConnector.NVMEInterface);
            NVMEFormFactor = new NVMEFormFactor.DTO.Details(MotherboardNVMEConnector.NVMEFormFactor);
            Count = MotherboardNVMEConnector.Count;
        }
    }
}
