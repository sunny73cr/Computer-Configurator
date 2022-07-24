namespace ComputerConfigurator.Api.MountedStorageFormFactor.DTO
{
    public class Details
    {
        public Guid UUID { get; set; }
        public string Size { get; set; } = string.Empty;

        public Details()
        {

        }

        public Details(MountedStorageFormFactor MountedStorageFormFactor)
        {
            UUID = MountedStorageFormFactor.UUID;
            Size = MountedStorageFormFactor.Size;
        }
    }
}
