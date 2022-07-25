namespace ComputerConfigurator.Api.Chassis
{
    public class Chassis : Part.Part
    {
        public int LengthMM { get; set; }
        public int WidthMM { get; set; }
        public int HeightMM { get; set; }
        public int MaxGPULengthMM { get; set; }
        public int MaxPSULengthMM { get; set; }
        public int MaxCPUCoolerHeightMM { get; set; }
        public int PCIESlotCount { get; set; }

        public virtual Part.Part Part { get; set; } = null!;
        public virtual ICollection<ChassisAudioPort.ChassisAudioPort> ChassisAudioPort { get; set; } = new HashSet<ChassisAudioPort.ChassisAudioPort>();
        public virtual ICollection<ChassisFanSupport.ChassisFanSupport> ChassisFanSupport { get; set; } = new HashSet<ChassisFanSupport.ChassisFanSupport>();
        public virtual ICollection<ChassisFilterSupport.ChassisFilterSupport> ChassisFilterSupport { get; set; } = new HashSet<ChassisFilterSupport.ChassisFilterSupport>();
        public virtual ICollection<ChassisMotherboardFormFactorSupport.ChassisMotherboardFormFactorSupport> ChassisMotherboardFormFactorSupport { get; set; } = new HashSet<ChassisMotherboardFormFactorSupport.ChassisMotherboardFormFactorSupport>();
        public virtual ICollection<ChassisPowerSupplyFormFactorSupport.ChassisPowerSupplyFormFactorSupport> ChassisPowerSupplyFormFactorSupport { get; set; } = new HashSet<ChassisPowerSupplyFormFactorSupport.ChassisPowerSupplyFormFactorSupport>();
        public virtual ICollection<ChassisRadiatorSupport.ChassisRadiatorSupport> ChassisRadiatorSupport { get; set; } = new HashSet<ChassisRadiatorSupport.ChassisRadiatorSupport>();
        public virtual ICollection<ChassisUSBPort.ChassisUSBPort> ChassisUSBPort { get; set; } = new HashSet<ChassisUSBPort.ChassisUSBPort>();

        public Chassis()
        {

        }

        public Chassis(DTO.Create chassis)
        {
            LengthMM = chassis.LengthMM;
            WidthMM = chassis.WidthMM;
            HeightMM = chassis.HeightMM;
            MaxGPULengthMM = chassis.MaxGPULengthMM;
            MaxPSULengthMM = chassis.MaxPSULengthMM;
            MaxCPUCoolerHeightMM = chassis.MaxCPUCoolerHeightMM;
            PCIESlotCount = chassis.PCIESlotCount;
        }

        public static void Edit(Chassis chassis, DTO.Edit edits)
        {
            if (chassis.LengthMM != edits.LengthMM) chassis.LengthMM = edits.LengthMM;
            if (chassis.WidthMM != edits.WidthMM) chassis.WidthMM = edits.WidthMM;
            if (chassis.HeightMM != edits.HeightMM) chassis.HeightMM = edits.HeightMM;
            if (chassis.MaxGPULengthMM != edits.MaxGPULengthMM) chassis.MaxGPULengthMM = edits.MaxGPULengthMM;
            if (chassis.MaxPSULengthMM != edits.MaxPSULengthMM) chassis.MaxPSULengthMM = edits.MaxPSULengthMM;
            if (chassis.MaxCPUCoolerHeightMM != edits.MaxCPUCoolerHeightMM) chassis.MaxCPUCoolerHeightMM = edits.MaxCPUCoolerHeightMM;
            if (chassis.PCIESlotCount != edits.PCIESlotCount) chassis.PCIESlotCount = edits.PCIESlotCount;
        }
    }
}
