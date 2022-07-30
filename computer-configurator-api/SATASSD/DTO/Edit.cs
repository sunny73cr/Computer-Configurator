namespace ComputerConfigurator.Api.SATASSD.DTO
{
    public class Edit : Storage.DTO.Edit
    {
        public Guid MountedStorageFormFactorUUID { get; set; }

        public override IReadOnlyList<string> Validate() => new Validation(this).Errors;
    }
}
