namespace ComputerConfigurator.Api.GPUDisplayConnector.DTO
{
    public class Create
    {
        public Guid DisplayConnectorUUID { get; set; }
        public int Count { get; set; }

        public IReadOnlyList<string> Validate() => new Validation(this).Errors;
    }
}
