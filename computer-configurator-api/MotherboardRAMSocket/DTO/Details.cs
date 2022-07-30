namespace ComputerConfigurator.Api.MotherboardRAMSocket.DTO
{
    public class Details
    {
        public RAMSocket.DTO.Details RAMSocket { get; set; }
        public int Count { get; set; }

        public Details(MotherboardRAMSocket MotherboardRAMSocket)
        {
            RAMSocket = new RAMSocket.DTO.Details(MotherboardRAMSocket.RAMSocket);
            Count = MotherboardRAMSocket.Count;
        }
    }
}
