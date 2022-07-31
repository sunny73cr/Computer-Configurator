namespace ComputerConfigurator.Api.CPUClosedLoopCooler.DTO
{
    public class Edit : CPUCooler.DTO.Edit
    {
        public Guid RadiatorSizeUUID { get; set; }

        public override IReadOnlyList<string> Validate() => new Validation(this).Errors;
    }
}
