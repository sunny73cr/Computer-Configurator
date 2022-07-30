namespace ComputerConfigurator.Api.Storage.DTO
{
    public abstract class Create : Part.DTO.Create
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
