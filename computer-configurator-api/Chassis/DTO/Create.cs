namespace ComputerConfigurator.Api.Chassis.DTO
{
    public class Create : Part.DTO.Create
    {
        public int LengthMM { get; set; }
        public int WidthMM { get; set; }
        public int HeightMM { get; set; }
        public int MaxGPULengthMM { get; set; }
        public int MaxPSULengthMM { get; set; }
        public int MaxCPUCoolerHeightMM { get; set; }
        public int PCIESlotCount { get; set; }
        public List<ChassisAudioPort.DTO.Create> AudioPorts { get; set; } = new();
        public List<ChassisFanSupport.DTO.Create> FanSupport { get; set; } = new();
        public List<ChassisFilterSupport.DTO.Create> FilterSupport { get; set; } = new();
        public List<ChassisMotherboardFormFactorSupport.DTO.Create> MotherboardFormFactorSupport { get; set; } = new();
        public List<ChassisPowerSupplyFormFactorSupport.DTO.Create> PowerSupplyFormFactorSupport { get; set; } = new();
        public List<ChassisRadiatorSupport.DTO.Create> RadiatorSupport { get; set; } = new();
        public List<ChassisUSBPort.DTO.Create> USBPorts { get; set; } = new();

        public override IReadOnlyList<string> Validate() => new Validation(this).Errors;
    }
}
