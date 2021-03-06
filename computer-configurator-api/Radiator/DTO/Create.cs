namespace ComputerConfigurator.Api.Radiator.DTO
{
    public class Create : Part.DTO.Create
    {
        public int WidthMM { get; set; }
        public Guid RadiatorSizeUUID { get; set; }
        public int TubeInnerDiameterMM { get; set; }
        public int TubeOuterDiameterMM { get; set; }

        public override IReadOnlyList<string> Validate() => new Validation(this).Errors;
    }
}
