namespace ComputerConfigurator.Api.ChassisUSBPort.DTO
{
    public class Details
    {
        public USBPort.DTO.Details USBPort { get; set; }
        public ChassisZone.DTO.Details ChassisZone { get; set; }
        public int Count { get; set; }

        public Details(ChassisUSBPort ChassisUSBPort)
        {
            USBPort = new USBPort.DTO.Details(ChassisUSBPort.USBPort);
            ChassisZone = new ChassisZone.DTO.Details(ChassisUSBPort.ChassisZone);
            Count = ChassisUSBPort.Count;
        }
    }
}
