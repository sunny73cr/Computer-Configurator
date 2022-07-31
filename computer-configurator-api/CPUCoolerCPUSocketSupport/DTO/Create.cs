namespace ComputerConfigurator.Api.CPUCoolerCPUSocketSupport.DTO
{
    public class Create
    {
        public Guid CPUCoolerUUID { get; set; }
        public Guid CPUSocketUUID { get; set; }

        public IReadOnlyList<string> Validate() => new Validation(this).Errors;
    }
}
