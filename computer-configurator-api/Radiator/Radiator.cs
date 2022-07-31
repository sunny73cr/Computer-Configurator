namespace ComputerConfigurator.Api.Radiator
{
    public class Radiator : Part.Part
    {
        public int WidthMM { get; set; }
        public Guid RadiatorSizeUUID { get; set; }
        public float TubeInnerDiameterMM { get; set; }
        public float TubeOuterDiameterMM { get; set; }

        public virtual Part.Part Part { get; set; } = null!;
        public virtual RadiatorSize.RadiatorSize RadiatorSize { get; set; } = null!;

        public Radiator()
        {

        }

        public Radiator(DTO.Create radiator) : base(radiator)
        {
            WidthMM = radiator.WidthMM;
            RadiatorSizeUUID = radiator.RadiatorSizeUUID;
            TubeInnerDiameterMM = radiator.TubeInnerDiameterMM;
            TubeOuterDiameterMM = radiator.TubeOuterDiameterMM;
        }

        public static void Edit(Radiator radiator, DTO.Edit edits)
        {
            Api.Part.Part.Edit(radiator, edits);

            if (radiator.WidthMM != edits.WidthMM) radiator.WidthMM = edits.WidthMM;
            if (radiator.RadiatorSizeUUID != edits.RadiatorSizeUUID) radiator.RadiatorSizeUUID = edits.RadiatorSizeUUID;
            if (radiator.TubeInnerDiameterMM != edits.TubeInnerDiameterMM) radiator.TubeInnerDiameterMM = edits.TubeInnerDiameterMM;
            if (radiator.TubeOuterDiameterMM != edits.TubeOuterDiameterMM) radiator.TubeOuterDiameterMM = edits.TubeOuterDiameterMM;
        }
    }
}
