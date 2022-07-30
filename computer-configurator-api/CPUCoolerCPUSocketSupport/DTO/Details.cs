namespace ComputerConfigurator.Api.CPUCoolerCPUSocketSupport.DTO
{
    public class Details
    {
        public CPUSocket.DTO.Details CPUSocket { get; set; }

        public Details(CPUCoolerCPUSocketSupport cpuCoolerCPUSocketSupport)
        {
            CPUSocket = new CPUSocket.DTO.Details(cpuCoolerCPUSocketSupport.CPUSocket);
        }
    }
}
