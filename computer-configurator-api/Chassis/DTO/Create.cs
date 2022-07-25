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
        public List<ChassisAudioPort.DTO.Create> ChassisAudioPorts { get; set; } = new();
        public List<ChassisAudioPort.DTO.Create> ChassisFanSupport { get; set; } = new();
        public List<ChassisAudioPort.DTO.Create> ChassisFilterSupport { get; set; } = new();
        public List<ChassisAudioPort.DTO.Create> ChassisMotherboardFormFactorSupport { get; set; } = new();
        public List<ChassisAudioPort.DTO.Create> ChassisPowerSupplyFormFactorSupport { get; set; } = new();
        public List<ChassisAudioPort.DTO.Create> ChassisRadiatorSupport { get; set; } = new();
        public List<ChassisAudioPort.DTO.Create> ChassisUSBPorts { get; set; } = new();

        public override IReadOnlyList<string> Validate() => new Validation(this).Errors;
    }
}
