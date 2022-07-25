namespace ComputerConfigurator.Api.ChassisAudioPort.DTO
{
    public class Create
    {
        public Guid AudioPortUUID { get; set; }
        public Guid ChassisZoneUUID { get; set; }

        public IReadOnlyList<string> Validate() => new Validation(this).Errors;
    }
}
