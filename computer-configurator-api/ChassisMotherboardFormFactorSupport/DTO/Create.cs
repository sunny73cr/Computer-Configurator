namespace ComputerConfigurator.Api.ChassisMotherboardFormFactorSupport.DTO
{
    public class Create
    {
        public Guid MotherboardFormFactorUUID { get; set; }

        public IReadOnlyList<string> Validate() => new Validation(this).Errors;
    }
}
