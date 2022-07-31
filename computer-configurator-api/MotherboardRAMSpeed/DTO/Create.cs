namespace ComputerConfigurator.Api.MotherboardRAMSpeed.DTO
{
    public class Create
    {
        public Guid RAMSpeedUUID { get; set; }
        public bool RequiresOverclock { get; set; }

        public IReadOnlyList<string> Validate() => new Validation(this).Errors;
    }
}
