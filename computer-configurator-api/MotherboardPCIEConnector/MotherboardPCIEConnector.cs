namespace ComputerConfigurator.Api.MotherboardPCIEConnector
{
    public class MotherboardPCIEConnector
    {
        public Guid MotherboardUUID { get; set; }
        public Guid PCIEConnectorUUID { get; set; }
        public int Count { get; set; }

        public virtual Motherboard.Motherboard Motherboard { get; set; } = null!;
        public virtual PCIEConnector.PCIEConnector PCIEConnector { get; set; } = null!;

        public MotherboardPCIEConnector()
        {

        }

        public MotherboardPCIEConnector(Guid motherboardUUID, DTO.Create MotherboardPCIEConnector)
        {
            MotherboardUUID = motherboardUUID;
            PCIEConnectorUUID = MotherboardPCIEConnector.PCIEConnectorUUID;
            Count = MotherboardPCIEConnector.Count;
        }

        public static void Edit(MotherboardPCIEConnector motherboardFanHeader, DTO.Edit edits)
        {
            if (motherboardFanHeader.Count != edits.Count) motherboardFanHeader.Count = edits.Count;
        }
    }
}
