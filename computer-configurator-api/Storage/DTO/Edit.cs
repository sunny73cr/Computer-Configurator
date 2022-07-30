namespace ComputerConfigurator.Api.Storage.DTO
{
    public abstract class Edit : Part.DTO.Edit
    {
        public int CapacityGBytes { get; set; }
        public int ReadBandwidth { get; set; }
        public int WriteBandwidth { get; set; }
        public int? ReadIOPS { get; set; }
        public int? WriteIOPS { get; set; }
        public int? MTBF { get; set; }
        public int? MaxTBW { get; set; }
        public int? CacheSizeMBytes { get; set; }
    }
}
