namespace ComputerConfigurator.Api.DisplayConnector;

public partial class DisplayConnector
{
    public Guid UUID { get; set; }
    public string Interface { get; set; } = string.Empty;
    public string Version { get; set; } = string.Empty;

    public DisplayConnector()
    {

    }

    public DisplayConnector(DTO.Create DisplayConnector)
    {
        UUID = DisplayConnector.UUID;
        Interface = DisplayConnector.Interface;
        Version = DisplayConnector.Version;
    }
}
