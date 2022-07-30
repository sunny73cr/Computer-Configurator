namespace ComputerConfigurator.Api.RAM.DTO
{
    public class Details : Part.DTO.Details
    {
        public RAMSocket.DTO.Details RAMSocket { get; set; }
        public RAMSpeed.DTO.Details RAMSpeed { get; set; }
        public int ModuleCapacityGBytes { get; set; }
        public int DIMMCount { get; set; }
        public int CAS { get; set; }
        public int TRCD { get; set; }
        public int TRP { get; set; }
        public int TRAS { get; set; }

        public Details(RAM ram) : base(ram)
        {
            RAMSocket = new RAMSocket.DTO.Details(ram.RAMSocket);
            RAMSpeed = new RAMSpeed.DTO.Details(ram.RAMSpeed);
            ModuleCapacityGBytes = ram.ModuleCapacityGBytes;
            DIMMCount = ram.DIMMCount;
            CAS = ram.CAS;
            TRCD = ram.TRCD;
            TRP = ram.TRP;
            TRAS = ram.TRAS;
        }
    }
}
