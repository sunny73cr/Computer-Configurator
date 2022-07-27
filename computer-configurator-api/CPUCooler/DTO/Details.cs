namespace ComputerConfigurator.Api.CPUCooler.DTO
{
    public abstract class Details : Part.DTO.Details
    {
        public int TDPRating { get; set; }
        public List<CPUCoolerFan.DTO.Details> CPUCoolerFans = new List<CPUCoolerFan.DTO.Details>();
        public List<CPUCoolerCPUSocketSupport.DTO.Details> CPUCoolerCPUSockets = new List<CPUCoolerCPUSocketSupport.DTO.Details>();

        public Details(CPUCooler cpuCooler) : base(cpuCooler)
        {
            TDPRating = cpuCooler.TDPRating;

            CPUCoolerFans.AddRange(
                cpuCooler.CPUCoolerFans.Select(
                    cpuCoolerFan => new CPUCoolerFan.DTO.Details(cpuCoolerFan)
                )
            );

            CPUCoolerCPUSockets.AddRange(
                cpuCooler.CPUSockets.Select(
                    cpuSocket => new CPUCoolerCPUSocketSupport.DTO.Details(cpuSocket)
                )
            );
        }
    }
}
