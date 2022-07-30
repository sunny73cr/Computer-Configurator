namespace ComputerConfigurator.Api.Motherboard.DTO
{
    public class Details : Part.DTO.Details
    {
        public CPUSocket.DTO.Details CPUSocket { get; set; } = null!;
        public int CPUSocketCount { get; set; }
        public MotherboardFormFactor.DTO.Details MotherboardFormFactor { get; set; } = null!;
        public MotherboardChipset.DTO.Details MotherboardChipset { get; set; } = null!;
        public bool WifiSupport { get; set; }
        public int MaxRAMCapacityMByte { get; set; }
        public List<MotherboardDisplayConnector.DTO.Details> DisplayConnectors { get; set; }
        public List<MotherboardEthernetPort.DTO.Details> EthernetPorts { get; set; }
        public List<MotherboardFanHeader.DTO.Details> FanHeaders { get; set; }
        public List<MotherboardNVMEConnector.DTO.Details> NVMEConnectors { get; set; }
        public List<MotherboardPCIEConnector.DTO.Details> PCIEConnectors { get; set; }
        public List<MotherboardRAMSocket.DTO.Details> RAMSockets { get; set; }
        public List<MotherboardRAMSpeed.DTO.Details> SupportedRAMSpeeds { get; set; }
        public List<MotherboardSATAConnector.DTO.Details> SATAConnectors { get; set; }
        public List<MotherboardUSBPort.DTO.Details> USBPorts { get; set; }

        public Details(Motherboard motherboard)
        {
            CPUSocket = new CPUSocket.DTO.Details(motherboard.CPUSocket);
            CPUSocketCount = motherboard.CPUSocketCount;
            MotherboardFormFactor = new MotherboardFormFactor.DTO.Details(motherboard.MotherboardFormFactor);
            MotherboardChipset = new MotherboardChipset.DTO.Details(motherboard.MotherboardChipset);
            WifiSupport = motherboard.WifiSupport;
            MaxRAMCapacityMByte = motherboard.MaxRAMCapacityMByte;
            //convert collections to DTO.Details
            DisplayConnectors = motherboard.DisplayConnectors.Select(x => new MotherboardDisplayConnector.DTO.Details(x)).ToList();
            EthernetPorts = motherboard.EthernetPorts.Select(x => new MotherboardEthernetPort.DTO.Details(x)).ToList();
            FanHeaders = motherboard.FanHeaders.Select(x => new MotherboardFanHeader.DTO.Details(x)).ToList();
            NVMEConnectors = motherboard.NVMEConnectors.Select(x => new MotherboardNVMEConnector.DTO.Details(x)).ToList();
            PCIEConnectors = motherboard.PCIEConnectors.Select(x => new MotherboardPCIEConnector.DTO.Details(x)).ToList();
            RAMSockets = motherboard.RAMSockets.Select(x => new MotherboardRAMSocket.DTO.Details(x)).ToList();
            SupportedRAMSpeeds = motherboard.SupportedRAMSpeeds.Select(x => new MotherboardRAMSpeed.DTO.Details(x)).ToList();
            SATAConnectors = motherboard.SATAConnectors.Select(x => new MotherboardSATAConnector.DTO.Details(x)).ToList();
            USBPorts = motherboard.USBPorts.Select(x => new MotherboardUSBPort.DTO.Details(x)).ToList();
        }
    }
}
