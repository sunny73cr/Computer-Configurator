namespace ComputerConfigurator.Api.MotherboardSATAConnector.DTO
{
    public class Create
    {
        public Guid SATAGenerationUUID { get; set; }
        public int Count { get; set; }

        public IReadOnlyList<string> Validate() => new Validation(this).Errors;
    }
}
