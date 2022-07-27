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
        public virtual List<ChassisAudioPort.ChassisAudioPort> AudioPorts { get; set; } = new List<ChassisAudioPort.ChassisAudioPort>();
        public virtual List<ChassisFanSupport.ChassisFanSupport> FanSupport { get; set; } = new List<ChassisFanSupport.ChassisFanSupport>();
        public virtual List<ChassisFilterSupport.ChassisFilterSupport> FilterSupport { get; set; } = new List<ChassisFilterSupport.ChassisFilterSupport>();
        public virtual List<ChassisMotherboardFormFactorSupport.ChassisMotherboardFormFactorSupport> MotherboardFormFactorSupport { get; set; } = new List<ChassisMotherboardFormFactorSupport.ChassisMotherboardFormFactorSupport>();
        public virtual List<ChassisPowerSupplyFormFactorSupport.ChassisPowerSupplyFormFactorSupport> PowerSupplyFormFactorSupport { get; set; } = new List<ChassisPowerSupplyFormFactorSupport.ChassisPowerSupplyFormFactorSupport>();
        public virtual List<ChassisRadiatorSupport.ChassisRadiatorSupport> RadiatorSupport { get; set; } = new List<ChassisRadiatorSupport.ChassisRadiatorSupport>();
        public virtual List<ChassisUSBPort.ChassisUSBPort> USBPorts { get; set; } = new List<ChassisUSBPort.ChassisUSBPort>();

        public Chassis()
        {

        }

        public Chassis(DTO.Create chassis) : base(chassis)
        {
            LengthMM = chassis.LengthMM;
            WidthMM = chassis.WidthMM;
            HeightMM = chassis.HeightMM;
            MaxGPULengthMM = chassis.MaxGPULengthMM;
            MaxPSULengthMM = chassis.MaxPSULengthMM;
            MaxCPUCoolerHeightMM = chassis.MaxCPUCoolerHeightMM;
            PCIESlotCount = chassis.PCIESlotCount;
            AudioPorts.AddRange(chassis.AudioPorts.Select(
                    createChassisAudioPort => new ChassisAudioPort.ChassisAudioPort(chassis.UUID, createChassisAudioPort)
            ));
            FanSupport.AddRange(chassis.FanSupport.Select(
                    createChassisFanSupport => new ChassisFanSupport.ChassisFanSupport(chassis.UUID, createChassisFanSupport)   
            ));
            FilterSupport.AddRange(chassis.FilterSupport.Select(
                    createChassisFilterSupport => new ChassisFilterSupport.ChassisFilterSupport(chassis.UUID, createChassisFilterSupport)    
            ));
            MotherboardFormFactorSupport.AddRange(chassis.MotherboardFormFactorSupport.Select(
                    createChassisMotherboardFormFactorSupport => new ChassisMotherboardFormFactorSupport.ChassisMotherboardFormFactorSupport(chassis.UUID, createChassisMotherboardFormFactorSupport)    
            ));
            PowerSupplyFormFactorSupport.AddRange(chassis.PowerSupplyFormFactorSupport.Select(
                    createPowerSupplyFormFactorSupport => new ChassisPowerSupplyFormFactorSupport.ChassisPowerSupplyFormFactorSupport(chassis.UUID, createPowerSupplyFormFactorSupport)    
            ));
            RadiatorSupport.AddRange(chassis.RadiatorSupport.Select(
                    createChassisRadiatorSupport => new ChassisRadiatorSupport.ChassisRadiatorSupport(chassis.UUID, createChassisRadiatorSupport)
            ));
            USBPorts.AddRange(chassis.USBPorts.Select(
                    createChassisUSBPorts => new ChassisUSBPort.ChassisUSBPort(chassis.UUID, createChassisUSBPorts)
            ));
        }

        public static void Edit(Chassis chassis, DTO.Edit edits)
        {
            Api.Part.Part.Edit(chassis, edits);

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
