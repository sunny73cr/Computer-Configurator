namespace ComputerConfigurator.Api.Motherboard
{
    public class Motherboard : Part.Part
    {
        public Guid CPUSocketUUID { get; set; }
        public int CPUSocketCount { get; set; }
        public Guid MotherboardFormFactorUUID { get; set; }
        public Guid MotherboardChipsetUUID { get; set; }
        public bool WifiSupport { get; set; }
        public int MaxRAMCapacityMByte { get; set; }

        public virtual Part.Part Part { get; set; } = null!;
        public virtual CPUSocket.CPUSocket CPUSocket { get; set; } = null!;
        public virtual MotherboardFormFactor.MotherboardFormFactor MotherboardFormFactor { get; set; } = null!;
        public virtual MotherboardChipset.MotherboardChipset MotherboardChipset { get; set; } = null!;

        public virtual List<MotherboardDisplayConnector.MotherboardDisplayConnector> DisplayConnectors { get; set; } = new();
        public virtual List<MotherboardEthernetPort.MotherboardEthernetPort> EthernetPorts { get; set; } = new();
        public virtual List<MotherboardFanHeader.MotherboardFanHeader> FanHeaders { get; set; } = new();
        public virtual List<MotherboardNVMEConnector.MotherboardNVMEConnector> NVMEConnectors { get; set; } = new();
        public virtual List<MotherboardPCIEConnector.MotherboardPCIEConnector> PCIEConnectors { get; set; } = new();
        public virtual List<MotherboardRAMSocket.MotherboardRAMSocket> RAMSockets { get; set; } = new();
        public virtual List<MotherboardRAMSpeed.MotherboardRAMSpeed> SupportedRAMSpeeds { get; set; } = new();
        public virtual List<MotherboardSATAConnector.MotherboardSATAConnector> SATAConnectors { get; set; } = new();
        public virtual List<MotherboardUSBPort.MotherboardUSBPort> USBPorts { get; set; } = new();

        public Motherboard()
        {

        }

        public Motherboard(DTO.Create motherboard)
        {
            MotherboardFormFactorUUID = motherboard.MotherboardFormFactorUUID;
            WifiSupport = motherboard.WifiSupport;
            MaxRAMCapacityMByte = motherboard.MaxRAMCapacityMByte;
            MotherboardChipsetUUID = motherboard.MotherboardChipsetUUID;
            CPUSocketUUID = motherboard.CPUSocketUUID;
            CPUSocketCount = motherboard.CPUSocketCount;
        }

        public static void Edit(Motherboard motherboard, DTO.Edit edits)
        {
            if (motherboard.CPUSocketUUID != edits.CPUSocketUUID) motherboard.CPUSocketUUID = edits.CPUSocketUUID;
            if (motherboard.CPUSocketCount != edits.CPUSocketCount) motherboard.CPUSocketCount = edits.CPUSocketCount;
            if (motherboard.MotherboardFormFactorUUID != edits.MotherboardFormFactorUUID) motherboard.MotherboardFormFactorUUID = edits.MotherboardFormFactorUUID;
            if (motherboard.MotherboardChipsetUUID != edits.MotherboardChipsetUUID) motherboard.MotherboardChipsetUUID = edits.MotherboardChipsetUUID;
            if (motherboard.WifiSupport != edits.WifiSupport) motherboard.WifiSupport = edits.WifiSupport;
            if (motherboard.MaxRAMCapacityMByte != edits.MaxRAMCapacityMByte) motherboard.MaxRAMCapacityMByte = edits.MaxRAMCapacityMByte;
        }
    }
}
