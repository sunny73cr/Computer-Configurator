namespace ComputerConfigurator.Api.Storage.DTO
{
    public abstract class Details : Part.DTO.Details
    {
        public int CapacityGBytes { get; set; }
        public int ReadBandwidth { get; set; }
        public int WriteBandwidth { get; set; }
        public int? ReadIOPS { get; set; }
        public int? WriteIOPS { get; set; }
        public int? MTBF { get; set; }
        public int? MaxTBW { get; set; }
        public int? CacheSizeMBytes { get; set; }

        public Details(Storage storage) : base(storage)
        {
            CapacityGBytes = storage.CapacityGBytes;
            ReadBandwidth = storage.ReadBandwidth;
            WriteBandwidth = storage.WriteBandwidth;
            ReadIOPS = storage.ReadIOPS;
            WriteIOPS = storage.WriteIOPS;
            MTBF = storage.MTBF;
            MaxTBW = storage.MaxTBW;
            CacheSizeMBytes = storage.CacheSizeMBytes;
        }
    }
}
