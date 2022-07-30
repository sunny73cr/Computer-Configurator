namespace ComputerConfigurator.Api.MotherboardEthernetPort.DTO
{
    public class Details
    {
        public EthernetPort.DTO.Details EthernetPort { get; set; }
        public int Count { get; set; }

        public Details(MotherboardEthernetPort MotherboardEthernetPort)
        {
            EthernetPort = new EthernetPort.DTO.Details(MotherboardEthernetPort.EthernetPort);
            Count = MotherboardEthernetPort.Count;
        }
    }
}
