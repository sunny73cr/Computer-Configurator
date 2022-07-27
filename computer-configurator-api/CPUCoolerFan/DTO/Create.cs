namespace ComputerConfigurator.Api.CPUCoolerFan.DTO
{
    public class Create
    {
        public Guid FanUUID { get; set; }
        public int Count { get; set; }

        public IReadOnlyList<string> Validate() => new Validation(this).Errors;
    }
}
