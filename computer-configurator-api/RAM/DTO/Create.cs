namespace ComputerConfigurator.Api.RAM.DTO
{
    public class Create : Part.DTO.Create
    {
        public Guid RAMSocketUUID { get; set; }
        public Guid RAMSpeedUUID { get; set; }
        public int ModuleCapacityGBytes { get; set; }
        public int DIMMCount { get; set; }
        public int CAS { get; set; }
        public int TRCD { get; set; }
        public int TRP { get; set; }
        public int TRAS { get; set; }

        public override IReadOnlyList<string> Validate() => new Validation(this).Errors;
    }
}
