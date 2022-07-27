namespace ComputerConfigurator.Api.Fan
{
    public class Fan : Part.Part
    {
        public Guid FanDiameterUUID { get; set; }
        public int WidthMM { get; set; }
        public bool PWMSupport { get; set; }
        public int MinRPM { get; set; }
        public int MaxRPM { get; set; }
        public float MinAirflow { get; set; }
        public float MaxAirflow { get; set; }
        public float MinStaticPressure { get; set; }
        public float MaxStaticPressure { get; set; }
        public float MinAcousticOutput { get; set; }
        public float MaxAcousticOutput { get; set; }
        public Guid FanVoltageUUID { get; set; }
        public float MaxCurrent { get; set; }
        public int MTBFHours { get; set; }

        public virtual Part.Part Part { get; set; } = null!;
        public virtual FanDiameter.FanDiameter FanDiameter { get; set; } = null!;
        public virtual FanVoltage.FanVoltage FanVoltage { get; set; } = null!;

        public Fan()
        {

        }

        public Fan(DTO.Create fan) : base(fan)
        {
            FanDiameterUUID = fan.FanDiameterUUID;
            WidthMM = fan.WidthMM;
            PWMSupport = fan.PWMSupport;
            MinRPM = fan.MinRPM;
            MaxRPM = fan.MaxRPM;
            MinAirflow = fan.MinAirflow;
            MaxAirflow = fan.MaxAirflow;
            MinStaticPressure = fan.MinStaticPressure;
            MaxStaticPressure = fan.MaxStaticPressure;
            MinAcousticOutput = fan.MinAcousticOutput;
            MaxAcousticOutput = fan.MaxAcousticOutput;
            FanVoltageUUID = fan.FanVoltageUUID;
            MaxCurrent = fan.MaxCurrent;
            MTBFHours = fan.MTBFHours;
        }

        public static void Edit(Fan fan, DTO.Edit edits)
        {
            Api.Part.Part.Edit(fan, edits);

            if (fan.FanDiameterUUID != edits.FanDiameterUUID) fan.FanDiameterUUID = edits.FanDiameterUUID;
            if (fan.WidthMM != edits.WidthMM) fan.WidthMM = edits.WidthMM;
            if (fan.PWMSupport != edits.PWMSupport) fan.PWMSupport = edits.PWMSupport;
            if (fan.MinRPM != edits.MinRPM) fan.MinRPM = edits.MinRPM;
            if (fan.MaxRPM != edits.MaxRPM) fan.MaxRPM = edits.MaxRPM;
            if (fan.MinAirflow != edits.MinAirflow) fan.MinAirflow = edits.MinAirflow;
            if (fan.MaxAirflow != edits.MaxAirflow) fan.MaxAirflow = edits.MaxAirflow;
            if (fan.MinStaticPressure != edits.MinStaticPressure) fan.MinStaticPressure = edits.MinStaticPressure;
            if (fan.MaxStaticPressure != edits.MaxStaticPressure) fan.MaxStaticPressure = edits.MaxStaticPressure;
            if (fan.MinAcousticOutput != edits.MinAcousticOutput) fan.MinAcousticOutput = edits.MinAcousticOutput;
            if (fan.MaxAcousticOutput != edits.MaxAcousticOutput) fan.MaxAcousticOutput = edits.MaxAcousticOutput;
            if (fan.FanVoltageUUID != edits.FanVoltageUUID) fan.FanVoltageUUID = edits.FanVoltageUUID;
            if (fan.MaxCurrent != edits.MaxCurrent) fan.MaxCurrent = edits.MaxCurrent;
            if (fan.MTBFHours != edits.MTBFHours) fan.MTBFHours = edits.MTBFHours;
        }
    }
}
