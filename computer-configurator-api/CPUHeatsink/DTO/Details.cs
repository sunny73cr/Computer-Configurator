namespace ComputerConfigurator.Api.CPUHeatsink.DTO
{
    public class Details : CPUCooler.DTO.Details
    {
        public int HeightMM { get; set; }

        public Details(CPUHeatsink cpuHeatsink) : base(cpuHeatsink)
        {
            HeightMM = cpuHeatsink.HeightMM;
        }
    }
}
