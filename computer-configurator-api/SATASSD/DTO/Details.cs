namespace ComputerConfigurator.Api.SATASSD.DTO
{
    public class Details : Storage.DTO.Details
    {
        public MountedStorageFormFactor.DTO.Details MountedStorageFormFactor { get; set; }

        public Details(SATASSD sataSSD) : base(sataSSD)
        {
            MountedStorageFormFactor = new MountedStorageFormFactor.DTO.Details(sataSSD.MountedStorageFormFactor);
        }
    }
}
