namespace ComputerConfigurator.Api.ChassisUSBPort.DTO
{
    public class Details
    {
        public Guid ChassisUUID { get; set; }
        public USBPort.DTO.Details USBPort { get; set; }
        public ChassisZone.DTO.Details ChassisZone { get; set; }
        public int Count { get; set; }

        public Details(ChassisUSBPort ChassisUSBPort)
        {
            ChassisUUID = ChassisUSBPort.ChassisUUID;
            USBPort = new USBPort.DTO.Details(ChassisUSBPort.USBPort);
            ChassisZone = new ChassisZone.DTO.Details(ChassisUSBPort.ChassisZone);
            Count = ChassisUSBPort.Count;
        }
    }
}
