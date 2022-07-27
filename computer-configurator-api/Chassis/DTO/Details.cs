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
        public List<ChassisAudioPort.DTO.Details> ChassisAudioPorts { get; set; } = new();
        public List<ChassisFanSupport.DTO.Details> ChassisFanSupport { get; set; } = new();
        public List<ChassisFilterSupport.DTO.Details> ChassisFilterSupport { get; set; } = new();
        public List<ChassisMotherboardFormFactorSupport.DTO.Details> ChassisMotherboardFormFactorSupport { get; set; } = new();
        public List<ChassisPowerSupplyFormFactorSupport.DTO.Details> ChassisPowerSupplyFormFactorSupport { get; set; } = new();
        public List<ChassisRadiatorSupport.DTO.Details> ChassisRadiatorSupport { get; set; } = new();
        public List<ChassisUSBPort.DTO.Details> ChassisUSBPorts { get; set; } = new();

        public Details(Chassis chassis) : base(chassis)
        {
            LengthMM = chassis.LengthMM;
            WidthMM = chassis.WidthMM;
            HeightMM = chassis.HeightMM;
            MaxGPULengthMM = chassis.MaxGPULengthMM;
            MaxPSULengthMM = chassis.MaxPSULengthMM;
            MaxCPUCoolerHeightMM = chassis.MaxCPUCoolerHeightMM;
            PCIESlotCount = chassis.PCIESlotCount;
            ChassisAudioPorts.AddRange(chassis.AudioPorts.Select(audioPort => new ChassisAudioPort.DTO.Details(audioPort)));
            ChassisFanSupport.AddRange(chassis.FanSupport.Select(fanSupport => new ChassisFanSupport.DTO.Details(fanSupport)));
            ChassisFilterSupport.AddRange(chassis.FilterSupport.Select(filterSupport => new ChassisFilterSupport.DTO.Details(filterSupport)));
            ChassisMotherboardFormFactorSupport.AddRange(chassis.MotherboardFormFactorSupport.Select(motherboardFormFactorSupport => new ChassisMotherboardFormFactorSupport.DTO.Details(motherboardFormFactorSupport)));
            ChassisPowerSupplyFormFactorSupport.AddRange(chassis.PowerSupplyFormFactorSupport.Select(powerSupplyFormFactorSupport => new ChassisPowerSupplyFormFactorSupport.DTO.Details(powerSupplyFormFactorSupport)));
            ChassisRadiatorSupport.AddRange(chassis.RadiatorSupport.Select(radiatorSupport => new ChassisRadiatorSupport.DTO.Details(radiatorSupport)));
            ChassisUSBPorts.AddRange(chassis.USBPorts.Select(usbPort => new ChassisUSBPort.DTO.Details(usbPort)));
        }
    }
}
