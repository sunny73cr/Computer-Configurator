namespace ComputerConfigurator.Api.Fan.DTO
{
    public class Edit : Part.DTO.Edit
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

        public override IReadOnlyList<string> Validate() => new Validation(this).Errors;
    }
}
