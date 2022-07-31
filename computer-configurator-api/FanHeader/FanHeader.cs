namespace ComputerConfigurator.Api.FanHeader;

public partial class FanHeader
{
    public Guid UUID { get; set; }
    public int PinCount { get; set; }

    public FanHeader()
    {

    }

    public FanHeader(DTO.Create FanHeader)
    {
        UUID = FanHeader.UUID;
        PinCount = FanHeader.PinCount;
    }
}
