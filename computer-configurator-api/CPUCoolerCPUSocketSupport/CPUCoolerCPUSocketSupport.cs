namespace ComputerConfigurator.Api.CPUCoolerCPUSocketSupport
{
    public class CPUCoolerCPUSocketSupport
    {
        public Guid CPUCoolerUUID { get; set; }
        public Guid CPUSocketUUID { get; set; }

        public CPUCooler.CPUCooler CPUCooler { get; set; } = null!;
        public CPUSocket.CPUSocket CPUSocket { get; set; } = null!;

        public CPUCoolerCPUSocketSupport()
        {

        }

        public CPUCoolerCPUSocketSupport(Guid cpuCoolerUUID, DTO.Create cpucoolercpusocketsupport)
        {
            CPUCoolerUUID = cpuCoolerUUID;
            CPUSocketUUID = cpucoolercpusocketsupport.CPUSocketUUID;
        }
    }
}
