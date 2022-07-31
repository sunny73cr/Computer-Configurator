namespace ComputerConfigurator.Api.SATAHDD.DTO
{
    public class Details : Storage.DTO.Details
    {
        public MountedStorageFormFactor.DTO.Details MountedStorageFormFactor { get; set; }
        public int SpindleRPM { get; set; }

        public Details(SATAHDD sataHDD) : base(sataHDD)
        {
            MountedStorageFormFactor = new MountedStorageFormFactor.DTO.Details(sataHDD.MountedStorageFormFactor);
            SpindleRPM = sataHDD.SpindleRPM;
        }
    }
}
