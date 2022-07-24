namespace ComputerConfigurator.Api.CPU
{
    public class CPU : Part.Part
    {
        public Guid CPUSocketUUID { get; set; }
        public int CoreCount { get; set; }
        public int ThreadCount { get; set; }
        public int BaseClockSpeed { get; set; }
        public int? BoostClockSpeed { get; set; }

        public virtual CPUSocket.CPUSocket CPUSocket { get; set; } = null!;
        public virtual Part.Part Part { get; set; } = null!;

        public CPU()
        {

        }

        public CPU(DTO.Create cpu) : base(cpu)
        {
            CPUSocketUUID = cpu.CPUSocketUUID;
            CoreCount = cpu.CoreCount;
            ThreadCount = cpu.ThreadCount;
            BaseClockSpeed = cpu.BaseClockSpeed;
            BoostClockSpeed = cpu.BoostClockSpeed;
        }

        public static void Edit(CPU cpu, DTO.Edit edits)
        {
            Api.Part.Part.Edit(cpu, edits);

            if (cpu.CPUSocketUUID != edits.CPUSocketUUID) cpu.CPUSocketUUID = edits.CPUSocketUUID;
            if (cpu.CoreCount != edits.CoreCount) cpu.CoreCount = edits.CoreCount;
            if (cpu.ThreadCount != edits.ThreadCount) cpu.ThreadCount = edits.ThreadCount;
            if (cpu.BaseClockSpeed != edits.BaseClockSpeed) cpu.BaseClockSpeed = edits.BaseClockSpeed;
            if (cpu.BoostClockSpeed != edits.BoostClockSpeed) cpu.BoostClockSpeed = edits.BoostClockSpeed;
        }
    }
}
