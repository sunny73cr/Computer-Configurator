namespace ComputerConfigurator.Api.NVMEInterface.DTO
{
    public class Details
    {
        public Guid UUID { get; set; }
        public string Interface { get; set; } = string.Empty;

        public Details()
        {

        }

        public Details(NVMEInterface NVMEInterface)
        {
            UUID = NVMEInterface.UUID;
            Interface = NVMEInterface.Interface;
        }
    }
}
