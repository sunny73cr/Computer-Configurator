namespace ComputerConfigurator.Api.SATASSD
{
    public class SATASSD : Storage.Storage
    {
        public Guid MountedStorageFormFactorUUID { get; set; }

        public virtual Storage.Storage Storage { get; set; } = null!;
        public virtual MountedStorageFormFactor.MountedStorageFormFactor MountedStorageFormFactor { get; set; } = null!;

        public SATASSD()
        {

        }

        public SATASSD(DTO.Create sataSSD) : base(sataSSD)
        {
            MountedStorageFormFactorUUID = sataSSD.MountedStorageFormFactorUUID;
        }

        public static void Edit(SATASSD sataSSD, DTO.Edit edits)
        {
            Api.Storage.Storage.Edit(sataSSD, edits);

            if (sataSSD.MountedStorageFormFactorUUID != edits.MountedStorageFormFactorUUID) sataSSD.MountedStorageFormFactorUUID = edits.MountedStorageFormFactorUUID;
        }
    }
}
