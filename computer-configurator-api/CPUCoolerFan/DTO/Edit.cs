namespace ComputerConfigurator.Api.CPUCoolerFan.DTO
{
    public class Edit
    {
        public Guid FanUUID { get; set; }
        public int Count { get; set; }

        public IReadOnlyList<string> Validate() => new Validation(this).Errors;
    }
}
