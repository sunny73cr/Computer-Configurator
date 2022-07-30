namespace ComputerConfigurator.Api.MotherboardRAMSocket.DTO
{
    public class Create
    {
        public Guid RAMSocketUUID { get; set; }
        public int Count { get; set; }

        public IReadOnlyList<string> Validate() => new Validation(this).Errors;
    }
}
