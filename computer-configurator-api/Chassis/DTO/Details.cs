namespace ComputerConfigurator.Api.Chassis.DTO
{
    public class Details : Part.DTO.Details
    {
        public int LengthMM { get; set; }
        public int WidthMM { get; set; }
        public int HeightMM { get; set; }
        public int MaxGPULengthMM { get; set; }
        public int MaxPSULengthMM { get; set; }
        public int MaxCPUCoolerHeightMM { get; set; }
        public int PCIESlotCount { get; set; }
        public List<ChassisAudioPort.DTO.Details> AudioPorts { get; set; } = new();
        public List<ChassisFanSupport.DTO.Details> FanSupport { get; set; } = new();
        public List<ChassisFilterSupport.DTO.Details> FilterSupport { get; set; } = new();
        public List<ChassisMotherboardFormFactorSupport.DTO.Details> MotherboardFormFactorSupport { get; set; } = new();
        public List<ChassisPowerSupplyFormFactorSupport.DTO.Details> PowerSupplyFormFactorSupport { get; set; } = new();
        public List<ChassisRadiatorSupport.DTO.Details> RadiatorSupport { get; set; } = new();
        public List<ChassisUSBPort.DTO.Details> USBPorts { get; set; } = new();

        public Details(Chassis chassis) : base(chassis)
        {
            LengthMM = chassis.LengthMM;
            WidthMM = chassis.WidthMM;
            HeightMM = chassis.HeightMM;
            MaxGPULengthMM = chassis.MaxGPULengthMM;
            MaxPSULengthMM = chassis.MaxPSULengthMM;
            MaxCPUCoolerHeightMM = chassis.MaxCPUCoolerHeightMM;
            PCIESlotCount = chassis.PCIESlotCount;
            AudioPorts.AddRange(chassis.AudioPorts.Select(audioPort => new ChassisAudioPort.DTO.Details(audioPort)));
            FanSupport.AddRange(chassis.FanSupport.Select(fanSupport => new ChassisFanSupport.DTO.Details(fanSupport)));
            FilterSupport.AddRange(chassis.FilterSupport.Select(filterSupport => new ChassisFilterSupport.DTO.Details(filterSupport)));
            MotherboardFormFactorSupport.AddRange(chassis.MotherboardFormFactorSupport.Select(motherboardFormFactorSupport => new ChassisMotherboardFormFactorSupport.DTO.Details(motherboardFormFactorSupport)));
            PowerSupplyFormFactorSupport.AddRange(chassis.PowerSupplyFormFactorSupport.Select(powerSupplyFormFactorSupport => new ChassisPowerSupplyFormFactorSupport.DTO.Details(powerSupplyFormFactorSupport)));
            RadiatorSupport.AddRange(chassis.RadiatorSupport.Select(radiatorSupport => new ChassisRadiatorSupport.DTO.Details(radiatorSupport)));
            USBPorts.AddRange(chassis.USBPorts.Select(usbPort => new ChassisUSBPort.DTO.Details(usbPort)));
        }
    }
}
