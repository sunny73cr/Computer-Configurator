namespace ComputerConfigurator.Api.NVMEFormFactor.DTO
{
    public class Edit
    {
        public Guid UUID { get; set; } = Guid.Empty;
        public string FormFactor { get; set; } = string.Empty;

        public IReadOnlyList<string> Validate() => new Validation(this).Errors;
    }
}
