namespace ComputerConfigurator.Api.Radiator.DTO
{
    public class Details : Part.DTO.Details
    {
        public int WidthMM { get; set; }
        public RadiatorSize.DTO.Details RadiatorSize { get; set; }
        public int TubeInnerDiameterMM { get; set; }
        public int TubeOuterDiameterMM { get; set; }

        public Details(Radiator radiator) : base(radiator)
        {
            WidthMM = radiator.WidthMM;
            RadiatorSize = new RadiatorSize.DTO.Details(radiator.RadiatorSize);
            TubeInnerDiameterMM = radiator.TubeInnerDiameterMM;
            TubeOuterDiameterMM = radiator.TubeOuterDiameterMM;
        }
    }
}
