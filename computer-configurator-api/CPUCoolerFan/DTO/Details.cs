namespace ComputerConfigurator.Api.CPUCoolerFan.DTO
{
    public class Details
    {
        public Fan.DTO.Details Fan { get; set; }
        public int Count { get; set; }

        public Details(CPUCoolerFan cpuCoolerFan)
        {
            Fan = new Fan.DTO.Details(cpuCoolerFan.Fan);
            Count = cpuCoolerFan.Count;
        }
    }
}
