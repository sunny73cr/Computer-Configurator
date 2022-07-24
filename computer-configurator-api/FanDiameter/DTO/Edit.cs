namespace ComputerConfigurator.Api.FanDiameter.DTO
{
    public class Edit
    {
        public Guid UUID { get; set; } = Guid.Empty;
        public int Diameter { get; set; }

        public IReadOnlyList<string> Validate() => new Validation(this).Errors;
    }
}
