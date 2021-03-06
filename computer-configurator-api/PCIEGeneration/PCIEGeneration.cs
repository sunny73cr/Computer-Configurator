namespace ComputerConfigurator.Api.PCIEGeneration;

public partial class PCIEGeneration
{
    public Guid UUID { get; set; }
    public string Generation { get; set; } = string.Empty;

    public virtual ICollection<PCIEConnector.PCIEConnector> PCIEConnectors { get; set; } = null!;

    public PCIEGeneration()
    {

    }

    public PCIEGeneration(DTO.Create PCIEGeneration)
    {
        UUID = PCIEGeneration.UUID;
        Generation = PCIEGeneration.Generation;
    }
}
