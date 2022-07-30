namespace ComputerConfigurator.Api.MotherboardDisplayConnector.DTO
{
    public class Edit
    {
        public Guid DisplayConnectorUUID { get; set; }
        public int Count { get; set; }

        public IReadOnlyList<string> Validate() => new Validation(this).Errors;
    }
}
