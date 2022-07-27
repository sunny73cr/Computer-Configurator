namespace ComputerConfigurator.Api.CPUCoolerCPUSocketSupport.DTO
{
    public class Details
    {
        public Guid CPUCoolerUUID { get; set; }
        public CPUSocket.DTO.Details CPUSocket { get; set; }

        public Details(CPUCoolerCPUSocketSupport cpuCoolerCPUSocketSupport)
        {
            CPUCoolerUUID = cpuCoolerCPUSocketSupport.CPUCoolerUUID;
            CPUSocket = new CPUSocket.DTO.Details(cpuCoolerCPUSocketSupport.CPUSocket);
        }
    }
}
