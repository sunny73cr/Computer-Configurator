namespace ComputerConfigurator.Api.MotherboardEthernetPort.DTO
{
    public class Edit
    {
        public Guid EthernetPortUUID { get; set; }
        public int Count { get; set; }

        public IReadOnlyList<string> Validate() => new Validation(this).Errors;
    }
}
