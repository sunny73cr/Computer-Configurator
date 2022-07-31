namespace ComputerConfigurator.Api.MotherboardRAMSocket
{
    public class MotherboardRAMSocket
    {
        public Guid MotherboardUUID { get; set; }
        public Guid RAMSocketUUID { get; set; }
        public int Count { get; set; }

        public virtual Motherboard.Motherboard Motherboard { get; set; } = null!;
        public virtual RAMSocket.RAMSocket RAMSocket { get; set; } = null!;

        public MotherboardRAMSocket()
        {

        }

        public MotherboardRAMSocket(Guid motherboardUUID, DTO.Create MotherboardRAMSocket)
        {
            MotherboardUUID = motherboardUUID;
            RAMSocketUUID = MotherboardRAMSocket.RAMSocketUUID;
            Count = MotherboardRAMSocket.Count;
        }

        public static void Edit(MotherboardRAMSocket MotherboardRAMSocket, DTO.Edit edits)
        {
            if (MotherboardRAMSocket.Count != edits.Count) MotherboardRAMSocket.Count = edits.Count;
        }
    }
}
