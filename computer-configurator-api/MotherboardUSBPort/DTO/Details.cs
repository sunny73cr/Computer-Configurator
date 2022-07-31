namespace ComputerConfigurator.Api.MotherboardUSBPort.DTO
{
    public class Details
    {
        public USBPort.DTO.Details USBPort { get; set; }
        public int ExternalCount { get; set; }
        public int InternalCount { get; set; }

        public Details(MotherboardUSBPort MotherboardUSBPort)
        {
            USBPort = new USBPort.DTO.Details(MotherboardUSBPort.USBPort);
            ExternalCount = MotherboardUSBPort.ExternalCount;
            InternalCount = MotherboardUSBPort.InternalCount;
        }
    }
}
