namespace ComputerConfigurator.Api.CPUHeatsink.DTO
{
    public class Create : CPUCooler.DTO.Create
    {
        public int HeightMM { get; set; }

        public override IReadOnlyList<string> Validate() => new Validation(this).Errors;
    }
}
