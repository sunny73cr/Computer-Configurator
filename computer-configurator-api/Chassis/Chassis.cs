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
        public virtual List<ChassisAudioPort.ChassisAudioPort> AudioPorts { get; set; } = new();
        public virtual List<ChassisFanSupport.ChassisFanSupport> FanSupport { get; set; } = new();
        public virtual List<ChassisFilterSupport.ChassisFilterSupport> FilterSupport { get; set; } = new();
        public virtual List<ChassisMotherboardFormFactorSupport.ChassisMotherboardFormFactorSupport> MotherboardFormFactorSupport { get; set; } = new();
        public virtual List<ChassisPowerSupplyFormFactorSupport.ChassisPowerSupplyFormFactorSupport> PowerSupplyFormFactorSupport { get; set; } = new();
        public virtual List<ChassisRadiatorSupport.ChassisRadiatorSupport> RadiatorSupport { get; set; } = new();
        public virtual List<ChassisUSBPort.ChassisUSBPort> USBPorts { get; set; } = new();

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

            AudioPorts = chassis.AudioPorts
                .Select(x => new ChassisAudioPort.ChassisAudioPort(chassis.UUID, x))
                .ToList();

            FanSupport = chassis.FanSupport
                .Select(x => new ChassisFanSupport.ChassisFanSupport(chassis.UUID, x))
                .ToList();

            FilterSupport = chassis.FilterSupport
                .Select(x => new ChassisFilterSupport.ChassisFilterSupport(chassis.UUID, x))
                .ToList();

            MotherboardFormFactorSupport = chassis.MotherboardFormFactorSupport
                .Select(x => new ChassisMotherboardFormFactorSupport.ChassisMotherboardFormFactorSupport(chassis.UUID, x))
                .ToList();

            PowerSupplyFormFactorSupport = chassis.PowerSupplyFormFactorSupport
                .Select(x => new ChassisPowerSupplyFormFactorSupport.ChassisPowerSupplyFormFactorSupport(chassis.UUID, x))
                .ToList();

            RadiatorSupport = chassis.RadiatorSupport
                .Select(x => new ChassisRadiatorSupport.ChassisRadiatorSupport(chassis.UUID, x))
                .ToList();

            USBPorts = chassis.USBPorts
                .Select(x => new ChassisUSBPort.ChassisUSBPort(chassis.UUID, x))
                .ToList();
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
