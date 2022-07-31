namespace ComputerConfigurator.Api.ChassisRadiatorSupport.DTO
{
    public class Create
    {
        public Guid RadiatorSizeUUID { get; set; }
        public Guid ChassisZoneUUID { get; set; }
        public int MaximumWidthMM { get; set; }

        public IReadOnlyList<string> Validate() => new Validation(this).Errors;
    }
}
