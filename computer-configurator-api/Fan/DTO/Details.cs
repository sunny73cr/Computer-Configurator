namespace ComputerConfigurator.Api.Fan.DTO
{
    public class Details : Part.DTO.Details
    {
        public FanDiameter.DTO.Details FanDiameter { get; set; }
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
        public FanVoltage.DTO.Details FanVoltage { get; set; }
        public float MaxCurrent { get; set; }
        public int MTBFHours { get; set; }

        public Details(Fan fan)
        {
            FanDiameter = new FanDiameter.DTO.Details(fan.FanDiameter);
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
            FanVoltage = new FanVoltage.DTO.Details(fan.FanVoltage);
            MaxCurrent = fan.MaxCurrent;
            MTBFHours = fan.MTBFHours;
        }
    }
}
