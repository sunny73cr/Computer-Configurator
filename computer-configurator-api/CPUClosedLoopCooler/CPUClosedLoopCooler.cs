namespace ComputerConfigurator.Api.CPUClosedLoopCooler
{
    public class CPUClosedLoopCooler : CPUCooler.CPUCooler
    {
        public Guid RadiatorSizeUUID { get; set; }

        public virtual CPUCooler.CPUCooler CPUCooler { get; set; } = null!;
        public virtual RadiatorSize.RadiatorSize RadiatorSize { get; set; } = null!;

        public CPUClosedLoopCooler()
        {

        }

        public CPUClosedLoopCooler(DTO.Create cpuclosedloopcooler) : base(cpuclosedloopcooler)
        {

        }

        public static void Edit(CPUClosedLoopCooler cpuClosedLoopCooler, DTO.Edit edits)
        {
            Api.CPUCooler.CPUCooler.Edit(cpuClosedLoopCooler, edits);

            if (cpuClosedLoopCooler.RadiatorSizeUUID != edits.RadiatorSizeUUID) cpuClosedLoopCooler.RadiatorSizeUUID = edits.RadiatorSizeUUID;
        }
    }
}
