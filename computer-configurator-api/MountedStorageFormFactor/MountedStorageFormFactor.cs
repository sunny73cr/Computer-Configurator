namespace ComputerConfigurator.Api.MountedStorageFormFactor;

public partial class MountedStorageFormFactor
{
    public Guid UUID { get; set; }
    public string Size { get; set; } = string.Empty;

    public MountedStorageFormFactor()
    {

    }

    public MountedStorageFormFactor(DTO.Create MountedStorageFormFactor)
    {
        UUID = MountedStorageFormFactor.UUID;
        Size = MountedStorageFormFactor.Size;
    }
}
