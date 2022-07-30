namespace ComputerConfigurator.Api.Motherboard.DTO
{
    public class Create : Part.DTO.Create
    {
        public Guid CPUSocketUUID { get; set; }
        public int CPUSocketCount { get; set; }
        public Guid MotherboardFormFactorUUID { get; set; }
        public Guid MotherboardChipsetUUID { get; set; }
        public bool WifiSupport { get; set; }
        public int MaxRAMCapacityMByte { get; set; }

        public virtual List<MotherboardDisplayConnector.DTO.Create> DisplayConnectors { get; set; } = new();
        public virtual List<MotherboardEthernetPort.DTO.Create> EthernetPorts { get; set; } = new();
        public virtual List<MotherboardFanHeader.DTO.Create> FanHeaders { get; set; } = new();
        public virtual List<MotherboardNVMEConnector.DTO.Create> NVMEConnectors { get; set; } = new();
        public virtual List<MotherboardPCIEConnector.DTO.Create> PCIEConnectors { get; set; } = new();
        public virtual List<MotherboardRAMSocket.DTO.Create> RAMSockets { get; set; } = new();
        public virtual List<MotherboardRAMSpeed.DTO.Create> RAMSpeeds { get; set; } = new();
        public virtual List<MotherboardSATAConnector.DTO.Create> SATAConnectors { get; set; } = new();
        public virtual List<MotherboardUSBPort.DTO.Create> USBPorts { get; set; } = new();

        public override IReadOnlyList<string> Validate() => new Validation(this).Errors;
    }
}
