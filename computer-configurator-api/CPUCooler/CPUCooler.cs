namespace ComputerConfigurator.Api.CPUCooler
{
    public abstract class CPUCooler : Part.Part
    {
        public int TDPRating { get; set; }

        public virtual Part.Part Part { get; set; } = null!;
        public virtual List<CPUCoolerFan.CPUCoolerFan> CPUCoolerFans { get; set; } = new();
        public virtual List<CPUCoolerCPUSocketSupport.CPUCoolerCPUSocketSupport> CPUSockets { get; set; } = new();

        public CPUCooler()
        {

        }

        public CPUCooler(DTO.Create cpucooler) : base(cpucooler)
        {
            TDPRating = cpucooler.TDPRating;
            CPUCoolerFans.AddRange(cpucooler.CPUCoolerFans.Select(
                cpuCoolerFan => new CPUCoolerFan.CPUCoolerFan(cpucooler.UUID, cpuCoolerFan)
            ));
            CPUSockets.AddRange(cpucooler.CPUCoolerCPUSocketSupport.Select(
                cpuCoolerCPUSocket => new CPUCoolerCPUSocketSupport.CPUCoolerCPUSocketSupport(cpucooler.UUID, cpuCoolerCPUSocket)
            ));
        }

        public static void Edit(CPUCooler cpuCooler, DTO.Edit edits)
        {
            Api.Part.Part.Edit(cpuCooler, edits);

            if (cpuCooler.TDPRating != edits.TDPRating) cpuCooler.TDPRating = edits.TDPRating;
        }
    }
}
