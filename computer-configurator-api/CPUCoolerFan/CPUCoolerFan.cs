namespace ComputerConfigurator.Api.CPUCoolerFan
{
    public class CPUCoolerFan
    {
        public Guid CPUCoolerUUID { get; set; }
        public Guid FanUUID { get; set; }
        public int Count { get; set; }

        public virtual CPUCooler.CPUCooler CPUCooler { get; set; } = null!;
        public virtual Fan.Fan Fan { get; set; } = null!;

        public CPUCoolerFan()
        {

        }

        public CPUCoolerFan(Guid cpuCoolerUUID, DTO.Create cpucoolerfan)
        {
            CPUCoolerUUID = cpuCoolerUUID;
            FanUUID = cpucoolerfan.FanUUID;
            Count = cpucoolerfan.Count;
        }

        public static void Edit(CPUCoolerFan cpuCoolerFan, DTO.Edit edits)
        {
            if (cpuCoolerFan.Count != edits.Count) cpuCoolerFan.Count = edits.Count;
        }
    }
}
