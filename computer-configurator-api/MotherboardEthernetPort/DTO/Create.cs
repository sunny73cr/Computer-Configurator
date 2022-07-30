namespace ComputerConfigurator.Api.MotherboardEthernetPort.DTO
{
    public class Create
    {
        public Guid EthernetPortUUID { get; set; }
        public int Count { get; set; }

        public IReadOnlyList<string> Validate() => new Validation(this).Errors;
    }
}
