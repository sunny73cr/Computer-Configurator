namespace ComputerConfigurator.Api.CPUClosedLoopCooler.DTO
{
    public class Details : CPUCooler.DTO.Details
    {
        public RadiatorSize.DTO.Details RadiatorSize { get; set; }

        public Details(CPUClosedLoopCooler cpuClosedLoopCooler) : base(cpuClosedLoopCooler)
        {
            RadiatorSize = new RadiatorSize.DTO.Details(cpuClosedLoopCooler.RadiatorSize);
        }
    }
}
