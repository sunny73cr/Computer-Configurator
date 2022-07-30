namespace ComputerConfigurator.Api.MotherboardNVMEConnector
{
    public class MotherboardNVMEConnector
    {
        public Guid MotherboardUUID { get; set; }
        public Guid PCIEGenerationUUID { get; set; }
        public Guid NVMEInterfaceUUID { get; set; }
        public Guid NVMEFormFactorUUID { get; set; }
        public int Count { get; set; }

        public virtual Motherboard.Motherboard Motherboard { get; set; } = null!;
        public virtual PCIEGeneration.PCIEGeneration PCIEGeneration { get; set; } = null!;
        public virtual NVMEInterface.NVMEInterface NVMEInterface { get; set; } = null!;
        public virtual NVMEFormFactor.NVMEFormFactor NVMEFormFactor { get; set; } = null!;

        public MotherboardNVMEConnector()
        {

        }

        public MotherboardNVMEConnector(Guid motherboardUUID, DTO.Create MotherboardNVMEConnector)
        {
            MotherboardUUID = motherboardUUID;
            PCIEGenerationUUID = MotherboardNVMEConnector.PCIEGenerationUUID;
            NVMEInterfaceUUID = MotherboardNVMEConnector.NVMEInterfaceUUID;
            NVMEFormFactorUUID = MotherboardNVMEConnector.NVMEFormFactorUUID;
            Count = MotherboardNVMEConnector.Count;
        }

        public static void Edit(MotherboardNVMEConnector MotherboardNVMEConnector, DTO.Edit edits)
        {
            if (MotherboardNVMEConnector.Count != edits.Count) MotherboardNVMEConnector.Count = edits.Count;
        }
    }
}
