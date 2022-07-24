namespace ComputerConfigurator.Api.PCIEConnector;

public partial class PCIEConnector
{
    public Guid UUID { get; set; }
    public Guid PCIEGenerationUUID { get; set; }
    public int LaneCount { get; set; }

    public virtual PCIEGeneration.PCIEGeneration PCIEGeneration { get; set; } = null!;

    public PCIEConnector()
    {

    }

    public PCIEConnector(DTO.Create PCIEConnector)
    {
        UUID = PCIEConnector.UUID;
        PCIEGenerationUUID = PCIEConnector.PCIEGenerationUUID;
        LaneCount = PCIEConnector.LaneCount;
    }

    public static void Edit(PCIEConnector PCIEConnector, DTO.Edit edits)
    {
        if (PCIEConnector.PCIEGenerationUUID != edits.PCIEGenerationUUID) PCIEConnector.PCIEGenerationUUID = edits.PCIEGenerationUUID;
        if (PCIEConnector.LaneCount != edits.LaneCount) PCIEConnector.LaneCount = edits.LaneCount;
    }
}
