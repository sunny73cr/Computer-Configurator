namespace ComputerConfigurator.Api.Storage
{
    public abstract class Storage : Part.Part
    {
        public int CapacityGBytes { get; set; }
        public int ReadBandwidth { get; set; }
        public int WriteBandwidth { get; set; }
        public int? ReadIOPS { get; set; }
        public int? WriteIOPS { get; set; }
        public int? MTBF { get; set; }
        public int? MaxTBW { get; set; }
        public int? CacheSizeMBytes { get; set; }

        public virtual Part.Part Part { get; set; } = null!;

        public Storage()
        {

        }

        public Storage(DTO.Create storage) : base(storage)
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

        public static void Edit(Storage storage, DTO.Edit edits)
        {
            Api.Part.Part.Edit(storage, edits);

            if (storage.CapacityGBytes != edits.CapacityGBytes) storage.CapacityGBytes = edits.CapacityGBytes;
            if (storage.ReadBandwidth != edits.ReadBandwidth) storage.ReadBandwidth = edits.ReadBandwidth;
            if (storage.WriteBandwidth != edits.WriteBandwidth) storage.WriteBandwidth = edits.WriteBandwidth;
            if (storage.ReadIOPS != edits.ReadIOPS) storage.ReadIOPS = edits.ReadIOPS;
            if (storage.WriteIOPS != edits.WriteIOPS) storage.WriteIOPS = edits.WriteIOPS;
            if (storage.MTBF != edits.MTBF) storage.MTBF = edits.MTBF;
            if (storage.MaxTBW != edits.MaxTBW) storage.MaxTBW = edits.MaxTBW;
            if (storage.CacheSizeMBytes != edits.CacheSizeMBytes) storage.CacheSizeMBytes = edits.CacheSizeMBytes;
        }
    }
}
