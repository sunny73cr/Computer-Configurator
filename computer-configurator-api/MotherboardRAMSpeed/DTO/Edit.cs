namespace ComputerConfigurator.Api.MotherboardRAMSpeed.DTO
{
    public class Edit
    {
        public Guid RAMSocketUUID { get; set; }
        public bool RequiresOverclock { get; set; }

        public IReadOnlyList<string> Validate() => new Validation(this).Errors;
    }
}
