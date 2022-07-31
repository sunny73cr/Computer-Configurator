namespace ComputerConfigurator.Api.NVMESSD.DTO
{
    public class Details : Storage.DTO.Details
    {
        public NVMEFormFactor.DTO.Details NVMEFormFactor { get; set; }
        public NVMEInterface.DTO.Details NVMEInterface { get; set; }

        public Details(NVMESSD nvmeSSD) : base(nvmeSSD)
        {
            NVMEFormFactor = new NVMEFormFactor.DTO.Details(nvmeSSD.NVMEFormFactor);
            NVMEInterface = new NVMEInterface.DTO.Details(nvmeSSD.NVMEInterface);
        }
    }
}
