namespace ComputerConfigurator.Api.ChassisFilterSupport.DTO
{
    public class Edit
    {
        public Guid ChassisZoneUUID { get; set; }
        public bool Removeable { get; set; }

        public IReadOnlyList<string> Validate() => new Validation(this).Errors;
    }
}
