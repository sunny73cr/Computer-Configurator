namespace ComputerConfigurator.Api.CPU.DTO
{
    public class Create : Part.DTO.Create
    {
        public Guid CPUSocketUUID { get; set; }
        public int CoreCount { get; set; }
        public int ThreadCount { get; set; }
        public int BaseClockSpeed { get; set; }
        public int? BoostClockSpeed { get; set; }

        public override IReadOnlyList<string> Validate() => new Validation(this).Errors;
    }
}
