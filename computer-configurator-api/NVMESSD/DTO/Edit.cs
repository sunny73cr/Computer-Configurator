namespace ComputerConfigurator.Api.NVMESSD.DTO
{
    public class Edit : Storage.DTO.Edit
    {
        public Guid NVMEFormFactorUUID { get; set; }
        public Guid NVMEInterfaceUUID { get; set; }

        public override IReadOnlyList<string> Validate() => new Validation(this).Errors;
    }
}
