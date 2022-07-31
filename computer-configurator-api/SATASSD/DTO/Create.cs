namespace ComputerConfigurator.Api.SATASSD.DTO
{
    public class Create : Storage.DTO.Create
    {
        public Guid MountedStorageFormFactorUUID { get; set; }

        public override IReadOnlyList<string> Validate() => new Validation(this).Errors;
    }
}
