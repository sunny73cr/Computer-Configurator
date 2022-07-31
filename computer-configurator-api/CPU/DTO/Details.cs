namespace ComputerConfigurator.Api.CPU.DTO
{
    public class Details : Part.DTO.Details
    {
        public CPUSocket.DTO.Details CPUSocket { get; set; } = default!;
        public int CoreCount { get; set; }
        public int ThreadCount { get; set; }
        public int BaseClockSpeed { get; set; }
        public int? BoostClockSpeed { get; set; }

        public Details(CPU cpu) : base(cpu)
        {
            CPUSocket = new CPUSocket.DTO.Details(cpu.CPUSocket);
            CoreCount = cpu.CoreCount;
            ThreadCount = cpu.ThreadCount;
            BaseClockSpeed = cpu.BaseClockSpeed;
            BoostClockSpeed = cpu.BoostClockSpeed;
        }
    }
}
