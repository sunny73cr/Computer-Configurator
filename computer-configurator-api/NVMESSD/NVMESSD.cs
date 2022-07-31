namespace ComputerConfigurator.Api.NVMESSD
{
    public class NVMESSD : Storage.Storage
    {
        public Guid NVMEFormFactorUUID { get; set; }
        public Guid NVMEInterfaceUUID { get; set; }

        public virtual Storage.Storage Storage { get; set; } = null!;
        public virtual NVMEFormFactor.NVMEFormFactor NVMEFormFactor { get; set; } = null!;
        public virtual NVMEInterface.NVMEInterface NVMEInterface { get; set; } = null!;

        public NVMESSD()
        {

        }

        public NVMESSD(DTO.Create nvmeSSD) : base(nvmeSSD)
        {
            NVMEFormFactorUUID = nvmeSSD.NVMEFormFactorUUID;
            NVMEInterfaceUUID = nvmeSSD.NVMEInterfaceUUID;
        }

        public static void Edit(NVMESSD nvmeSSD, DTO.Edit edits)
        {
            Api.Storage.Storage.Edit(nvmeSSD, edits);

            if (nvmeSSD.NVMEFormFactorUUID != edits.NVMEFormFactorUUID) nvmeSSD.NVMEFormFactorUUID = edits.NVMEFormFactorUUID;
            if (nvmeSSD.NVMEInterfaceUUID != edits.NVMEInterfaceUUID) nvmeSSD.NVMEInterfaceUUID = edits.NVMEInterfaceUUID;
        }
    }
}
