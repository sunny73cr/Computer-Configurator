namespace ComputerConfigurator.Api.RAM
{
    public class RAM : Part.Part
    {
        public Guid RAMSocketUUID { get; set; }
        public Guid RAMSpeedUUID { get; set; }
        public int ModuleCapacityGBytes { get; set; }
        public int DIMMCount { get; set; }
        public int CAS { get; set; }
        public int TRCD { get; set; }
        public int TRP { get; set; }
        public int TRAS { get; set; }

        public virtual Part.Part Part { get; set; } = null!;
        public virtual RAMSocket.RAMSocket RAMSocket { get; set; } = null!;
        public virtual RAMSpeed.RAMSpeed RAMSpeed { get; set; } = null!;

        public RAM()
        {

        }

        public RAM(DTO.Create ram) : base(ram)
        {
            RAMSocketUUID = ram.RAMSocketUUID;
            RAMSpeedUUID = ram.RAMSpeedUUID;
            ModuleCapacityGBytes = ram.ModuleCapacityGBytes;
            DIMMCount = ram.DIMMCount;
            CAS = ram.CAS;
            TRCD = ram.TRCD;
            TRP = ram.TRP;
            TRAS = ram.TRAS;
        }

        public static void Edit(RAM ram, DTO.Edit edits)
        {
            Api.Part.Part.Edit(ram, edits);

            if (ram.RAMSocketUUID != edits.RAMSocketUUID) ram.RAMSocketUUID = edits.RAMSocketUUID;
            if (ram.RAMSpeedUUID != edits.RAMSpeedUUID) ram.RAMSpeedUUID = edits.RAMSpeedUUID;
            if (ram.ModuleCapacityGBytes != edits.ModuleCapacityGBytes) ram.ModuleCapacityGBytes = edits.ModuleCapacityGBytes;
            if (ram.DIMMCount != edits.DIMMCount) ram.DIMMCount = edits.DIMMCount;
            if (ram.CAS != edits.CAS) ram.CAS = edits.CAS;
            if (ram.TRCD != edits.TRCD) ram.TRCD = edits.TRCD;
            if (ram.TRP != edits.TRP) ram.TRP = edits.TRP;
            if (ram.TRAS != edits.TRAS) ram.TRAS = edits.TRAS;
        }
    }
}
