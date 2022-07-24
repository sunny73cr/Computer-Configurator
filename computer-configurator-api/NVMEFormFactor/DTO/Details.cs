namespace ComputerConfigurator.Api.NVMEFormFactor.DTO
{
    public class Details
    {
        public Guid UUID { get; set; }
        public string FormFactor { get; set; } = string.Empty;

        public Details()
        {

        }

        public Details(NVMEFormFactor NVMEFormFactor)
        {
            UUID = NVMEFormFactor.UUID;
            FormFactor = NVMEFormFactor.FormFactor;
        }
    }
}
