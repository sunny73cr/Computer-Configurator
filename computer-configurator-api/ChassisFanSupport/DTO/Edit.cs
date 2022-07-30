namespace ComputerConfigurator.Api.ChassisFanSupport.DTO
{
    public class Edit
    {
        public Guid FanDiameterUUID { get; set; }
        public Guid ChassisZoneUUID { get; set; }
        public int MaximumWidthMM { get; set; }
        public int Count { get; set; }

        public IReadOnlyList<string> Validate() => new Validation(this).Errors;
    }
}
