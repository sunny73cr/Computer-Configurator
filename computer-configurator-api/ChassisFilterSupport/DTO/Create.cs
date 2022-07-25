namespace ComputerConfigurator.Api.ChassisFilterSupport.DTO
{
    public class Create
    {
        public Guid ChassisZoneUUID { get; set; }
        public bool Removeable { get; set; }

        public IReadOnlyList<string> Validate() => new Validation(this).Errors;
    }
}
