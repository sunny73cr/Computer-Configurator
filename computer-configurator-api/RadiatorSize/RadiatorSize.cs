namespace ComputerConfigurator.Api.RadiatorSize;

public partial class RadiatorSize
{
    public Guid UUID { get; set; }
    public int Size { get; set; }

    public RadiatorSize()
    {

    }

    public RadiatorSize(DTO.Create RadiatorSize)
    {
        UUID = RadiatorSize.UUID;
        Size = RadiatorSize.Size;
    }
}
