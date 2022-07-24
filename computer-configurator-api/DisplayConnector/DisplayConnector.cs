namespace ComputerConfigurator.Api.DisplayConnector;

public partial class DisplayConnector
{
    public Guid UUID { get; set; }
    public string Interface { get; set; } = null!;
    public string Version { get; set; } = null!;

    public DisplayConnector()
    {

    }

    public DisplayConnector(DTO.Create DisplayConnector)
    {
        UUID = DisplayConnector.UUID;
        Interface = DisplayConnector.Interface;
        Version = DisplayConnector.Version;
    }

    public static void Edit(DisplayConnector DisplayConnector, DTO.Edit edits)
    {
        if (DisplayConnector.Interface != edits.Interface) DisplayConnector.Interface = edits.Interface;
        if (DisplayConnector.Version != edits.Version) DisplayConnector.Version = edits.Version;
    }
}
