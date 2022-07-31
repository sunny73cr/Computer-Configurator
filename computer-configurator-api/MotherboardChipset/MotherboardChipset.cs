namespace ComputerConfigurator.Api.MotherboardChipset;

public partial class MotherboardChipset
{
    public Guid UUID { get; set; }
    public Guid ManufacturerUUID { get; set; }
    public Guid CPUSocketUUID { get; set; }
    public string Version { get; set; } = string.Empty;

    public virtual Manufacturer.Manufacturer Manufacturer { get; set; } = null!;
    public virtual CPUSocket.CPUSocket CPUSocket { get; set; } = null!;

    public MotherboardChipset()
    {

    }

    public MotherboardChipset(DTO.Create MotherboardChipset)
    {
        UUID = MotherboardChipset.UUID;
        ManufacturerUUID = MotherboardChipset.ManufacturerUUID;
        CPUSocketUUID = MotherboardChipset.CPUSocketUUID;
        Version = MotherboardChipset.Version;
    }
}
