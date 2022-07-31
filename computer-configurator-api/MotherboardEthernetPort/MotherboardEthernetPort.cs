namespace ComputerConfigurator.Api.MotherboardEthernetPort
{
    public class MotherboardEthernetPort
    {
        public Guid MotherboardUUID { get; set; }
        public Guid EthernetPortUUID { get; set; }
        public int Count { get; set; }

        public virtual Motherboard.Motherboard Motherboard { get; set; } = null!;
        public virtual EthernetPort.EthernetPort EthernetPort { get; set; } = null!;

        public MotherboardEthernetPort()
        {

        }

        public MotherboardEthernetPort(Guid motherboardUUID, DTO.Create MotherboardEthernetPort)
        {
            MotherboardUUID = motherboardUUID;
            EthernetPortUUID = MotherboardEthernetPort.EthernetPortUUID;
            Count = MotherboardEthernetPort.Count;
        }

        public static void Edit(MotherboardEthernetPort motherboardEthernetPort, DTO.Edit edits)
        {
            if (motherboardEthernetPort.Count != edits.Count) motherboardEthernetPort.Count = edits.Count;
        }
    }
}
