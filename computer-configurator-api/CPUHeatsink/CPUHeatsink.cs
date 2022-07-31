namespace ComputerConfigurator.Api.CPUHeatsink
{
    public class CPUHeatsink : CPUCooler.CPUCooler
    {
        public int HeightMM { get; set; }

        public virtual CPUCooler.CPUCooler CPUCooler { get; set; } = null!;

        public CPUHeatsink()
        {

        }

        public CPUHeatsink(DTO.Create cpuheatsink) : base(cpuheatsink)
        {
            HeightMM = cpuheatsink.HeightMM;
        }

        public static void Edit(CPUHeatsink cpuHeatsink, DTO.Edit edits)
        {
            Api.CPUCooler.CPUCooler.Edit(cpuHeatsink, edits);

            if (cpuHeatsink.HeightMM != edits.HeightMM) cpuHeatsink.HeightMM = edits.HeightMM;
        }
    }
}
