namespace ComputerConfigurator.Api.SATAHDD
{
    public class SATAHDD : Storage.Storage
    {
        public Guid MountedStorageFormFactorUUID { get; set; }
        public int SpindleRPM { get; set; }

        public virtual Storage.Storage Storage { get; set; } = null!;
        public virtual MountedStorageFormFactor.MountedStorageFormFactor MountedStorageFormFactor { get; set; } = null!;

        public SATAHDD()
        {

        }

        public SATAHDD(DTO.Create sataHDD) : base(sataHDD)
        {
            MountedStorageFormFactorUUID = sataHDD.MountedStorageFormFactorUUID;
            SpindleRPM = sataHDD.SpindleRPM;
        }

        public static void Edit(SATAHDD sataHDD, DTO.Edit edits)
        {
            Api.Storage.Storage.Edit(sataHDD, edits);

            if (sataHDD.MountedStorageFormFactorUUID != edits.MountedStorageFormFactorUUID) sataHDD.MountedStorageFormFactorUUID = edits.MountedStorageFormFactorUUID;
            if (sataHDD.SpindleRPM != edits.SpindleRPM) sataHDD.SpindleRPM = edits.SpindleRPM;
        }
    }
}
