namespace ComputerConfigurator.Api.SATAHDD.DTO
{
    public class Create : Storage.DTO.Create
    {
        public Guid MountedStorageFormFactorUUID { get; set; }
        public int SpindleRPM { get; set; }

        public override IReadOnlyList<string> Validate() => new Validation(this).Errors;
    }
}
