namespace ComputerConfigurator.Api.MotherboardUSBPort
{
    public class MotherboardUSBPort
    {
        public Guid MotherboardUUID { get; set; }
        public Guid USBPortUUID { get; set; }
        public int ExternalCount { get; set; }
        public int InternalCount { get; set; }

        public virtual Motherboard.Motherboard Motherboard { get; set; } = null!;
        public virtual USBPort.USBPort USBPort { get; set; } = null!;

        public MotherboardUSBPort()
        {

        }

        public MotherboardUSBPort(Guid motherboardUUID, DTO.Create MotherboardUSBPort)
        {
            MotherboardUUID = motherboardUUID;
            USBPortUUID = MotherboardUSBPort.USBPortUUID;
            ExternalCount = MotherboardUSBPort.ExternalCount;
            InternalCount = MotherboardUSBPort.InternalCount;
        }

        public static void Edit(MotherboardUSBPort MotherboardUSBPort, DTO.Edit edits)
        {
            if (MotherboardUSBPort.ExternalCount != edits.ExternalCount) MotherboardUSBPort.ExternalCount = edits.ExternalCount;
            if (MotherboardUSBPort.InternalCount != edits.InternalCount) MotherboardUSBPort.InternalCount = edits.InternalCount;
        }
    }
}
