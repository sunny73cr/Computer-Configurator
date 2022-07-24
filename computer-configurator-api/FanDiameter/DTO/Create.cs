namespace ComputerConfigurator.Api.FanDiameter.DTO
{
    public class Create
    {
        public Guid UUID { get; set; } = Guid.NewGuid();
        public int Diameter { get; set; }

        public IReadOnlyList<string> Validate() => new Validation(this).Errors;
    }
}
