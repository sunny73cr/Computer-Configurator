namespace ComputerConfigurator.Api.CPUCoolerFan.DTO
{
    public class Details
    {
        public Guid CPUCoolerUUID { get; set; }
        public Fan.DTO.Details Fan { get; set; }
        public int Count { get; set; }

        public Details(CPUCoolerFan cpuCoolerFan)
        {
            CPUCoolerUUID = cpuCoolerFan.CPUCoolerUUID;
            Fan = new Fan.DTO.Details(cpuCoolerFan.Fan);
            Count = cpuCoolerFan.Count;
        }
    }
}
