namespace ComputerConfigurator.Api.CPUCooler.DTO
{
    public abstract class Edit : Part.DTO.Edit
    {
        public int TDPRating { get; set; }

        public override IReadOnlyList<string> Validate() => new Validation(this).Errors;
    }
}
