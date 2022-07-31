namespace ComputerConfigurator.Api.CPUCooler.DTO
{
    public abstract class Create : Part.DTO.Create
    {
        public int TDPRating { get; set; }
        public List<CPUCoolerFan.DTO.Create> CPUCoolerFans { get; set; } = new();
        public List<CPUCoolerCPUSocketSupport.DTO.Create> CPUCoolerCPUSocketSupport { get; set; } = new();

        public override IReadOnlyList<string> Validate() => new Validation(this).Errors;
    }
}
