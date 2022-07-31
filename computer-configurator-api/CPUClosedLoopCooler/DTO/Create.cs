namespace ComputerConfigurator.Api.CPUClosedLoopCooler.DTO
{
    public class Create : CPUCooler.DTO.Create
    {
        public Guid RadiatorSizeUUID { get; set; }

        public override IReadOnlyList<string> Validate() => new Validation(this).Errors;
    }
}
