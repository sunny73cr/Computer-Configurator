namespace ComputerConfigurator.Api.MotherboardFanHeader.DTO
{
    public class Create
    {
        public Guid FanHeaderUUID { get; set; }
        public int Count { get; set; }

        public IReadOnlyList<string> Validate() => new Validation(this).Errors;
    }
}
