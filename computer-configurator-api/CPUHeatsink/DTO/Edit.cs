namespace ComputerConfigurator.Api.CPUHeatsink.DTO
{
    public class Edit : CPUCooler.DTO.Edit
    {
        public int HeightMM { get; set; }

        public override IReadOnlyList<string> Validate() => new Validation(this).Errors;
    }
}
