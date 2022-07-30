namespace ComputerConfigurator.Api.ChassisPowerSupplyFormFactorSupport.DTO
{
    public class Edit
    {
        public Guid PowerSupplyFormFactorUUID { get; set; }
        public bool BracketRequired { get; set; }

        public IReadOnlyList<string> Validate() => new Validation(this).Errors;
    }
}
