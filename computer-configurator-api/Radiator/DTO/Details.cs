namespace ComputerConfigurator.Api.Radiator.DTO
{
    public class Details : Part.DTO.Details
    {
        public int WidthMM { get; set; }
        public RadiatorSize.DTO.Details RadiatorSize { get; set; }
        public float TubeInnerDiameterMM { get; set; }
        public float TubeOuterDiameterMM { get; set; }

        public Details(Radiator radiator) : base(radiator)
        {
            WidthMM = radiator.WidthMM;
            RadiatorSize = new RadiatorSize.DTO.Details(radiator.RadiatorSize);
            TubeInnerDiameterMM = radiator.TubeInnerDiameterMM;
            TubeOuterDiameterMM = radiator.TubeOuterDiameterMM;
        }
    }
}
