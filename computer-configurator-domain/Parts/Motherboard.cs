namespace ComputerConfigurator.Domain.Parts.Motherboard;

public enum MotherboardFormFactor : int
{
    Mini_ITX = 0,
    Micro_ATX = 1,
    ATX = 2,
    Extended_ATX = 3
}

public class Motherboard : Part.Details
{
    public static readonly string FormFactorsDelimited = StringFormatters.DelimitEnumValues<MotherboardFormFactor>();

    public MotherboardFormFactor Size { get; set; } = default!;
    public string Chipset { get; set; } = default!;
    public string CPUSocketType { get; set; } = default!;
    public bool WiFiSupport { get; set; }
    public string RAMSocketType { get; set; } = default!;
    public int RAMSocketCount { get; set; }
    public int MaxRAMSize { get; set; }
    public List<RAMSpeedSupport> RAMCompatibility { get; set; } = default!;
    public List<PCIEConnector> PCIECompatibility { get; set; } = default!;
    public List<SATAConnector> SATACompatibility { get; set; } = default!;
    public List<NVMEConnector> NVMECompatibility { get; set; } = default!;
    public List<LANPort> LANPorts { get; set; } = default!;
    public List<USBConnector> USBConnectors { get; set; } = default!;
    public List<AudioConnector> AudioConnectors { get; set; } = default!;
    public List<FanHeader> FanHeaders { get; set; } = default!;

    public List<string> Validate()
    {
        List<string> errors = new();

        //Part.Part.Validate(errors, this);

        Validation.Enum.IsInEnum(errors, "Form factor", (int)Size, typeof(MotherboardFormFactor), FormFactorsDelimited);

        Validation.String.LengthRange(errors, "Chipset", Chipset, 1, 15);

        Validation.String.LengthRange(errors, "CPU Socket", CPUSocketType, 1, 32);

        //wifi support - not validated

        Validation.String.LengthRange(errors, "RAM slot type", RAMSocketType, 1, 15);

        Validation.Numeric.ValueRange(errors, "Numer of RAM slots", RAMSocketCount, 1, 15);

        Validation.Numeric.ValueRange(errors, "Maximum RAM capacity", MaxRAMSize, 1, 8192);

        RAMCompatibility.ForEach(ramCompatibility => ramCompatibility.Validate(errors));

        PCIECompatibility.ForEach(pcieCompatibility => pcieCompatibility.Validate(errors));

        SATACompatibility.ForEach(storageCompatibility => storageCompatibility.Validate(errors));

        NVMECompatibility.ForEach(nvmeCompatibility => nvmeCompatibility.Validate(errors));

        LANPorts.ForEach(lanPort => lanPort.Validate(errors));

        USBConnectors.ForEach(usbConnector => usbConnector.Validate(errors));

        AudioConnectors.ForEach(audioConnector => audioConnector.Validate(errors));

        FanHeaders.ForEach(fanHeader => fanHeader.Validate(errors));

        return errors;
    }
}

public class RAMSpeedSupport
{
    public int ClockRate { get; set; }
    public bool IsOverClockProfile { get; set; }

    public void Validate(List<string> errors)
    {
        Validation.Numeric.ValueRange(errors, "RAM clock rate", ClockRate, 800, 10000);
    }
}

public class PCIEConnector
{
    public int Length { get; set; }
    public int Version { get; set; }
    public int Count { get; set; }

    public void Validate(List<string> errors)
    {
        Validation.Numeric.ValueRange(errors, "PCIE connector length", Length, 4, 16);
        Validation.Numeric.ValueRange(errors, "PCIE connector version", Version, 1, 4);
        Validation.Numeric.ValueRange(errors, "PCIE connector count", Count, 0, 16);
    }
}

public abstract class StorageConnector
{
    public enum StorageConnectorType
    {
        SATA,
        PCIE
    }

    private static readonly string StorageConnectorTypesDelimited = StringFormatters.DelimitEnumValues<StorageConnectorType>();

    public StorageConnectorType Type { get; set; } = default!;
    public int Count { get; set; }
    public string Location { get; set; } = default!;

    protected void Validate(List<string> errors)
    {
        Validation.Enum.IsInEnum(errors, "Storage connector type", (int)Type, typeof(StorageConnectorType), StorageConnectorTypesDelimited);
        Validation.Numeric.ValueRange(errors, "Storage connector count", Count, 1, 40);
        Validation.String.LengthRange(errors, "Storage connector location", Location, 3, 30);
    }
}

public class SATAConnector : StorageConnector
{
    public static readonly string[] Bandwidths = new[]
    {
        "2",
        "3",
    };

    public static readonly string BandwidthsDelimited = Bandwidths.Delimit();

    public string MinimumSupportedSpeed { get; set; } = default!;
    public string MaximumSupportedSpeed { get; set; } = default!;

    new public void Validate(List<string> errors)
    {
        base.Validate(errors);

        Validation.String.ValueOption(errors, "Minimum SATA Speed", MinimumSupportedSpeed, Bandwidths, BandwidthsDelimited);
        Validation.String.ValueOption(errors, "Maximum SATA Speed", MaximumSupportedSpeed, Bandwidths, BandwidthsDelimited);
    }
}

public class NVMEConnector : StorageConnector
{
    public static readonly int[] Lengths = new[]
    {
        2230,
        2242,
        2280,
        22110
    };

    public static readonly string LengthsDelimited = Lengths.Delimit();

    public int MinimumSupportedLength { get; set; }
    public int MaximumSupportedLength { get; set; }
    
    new public void Validate(List<string> errors)
    {
        base.Validate(errors);

        Validation.Numeric.ValueOption(errors, "Minimum NVME form factor", MinimumSupportedLength, Lengths, LengthsDelimited);
        Validation.Numeric.ValueOption(errors, "Maximum NVME form factor", MaximumSupportedLength, Lengths, LengthsDelimited);
    }
}

public class LANPort
{
    public string Type { get; set; } = default!;
    public int Bandwidth { get; set; }

    public void Validate(List<string> errors)
    {
        Validation.String.LengthRange(errors, "LAN port type", Type, 1, 20);
        Validation.Numeric.ValueRange(errors, "LAN port bandwidth", Bandwidth, 100, 100000);
    }
}

public class AudioConnector
{
    public string Type { get; set; }
    public int Count { get; set; }

    public AudioConnector(
        string type,
        int count
    )
    {
        this.Type = type;
        this.Count = count;
    }

    public void Validate(List<string> errors)
    {
        Validation.String.LengthRange(errors, "Audio connector type", Type, 1, 30);
        Validation.Numeric.ValueRange(errors, "Number of audio connectors", Count, 1, 10);
    }
}

public class USBConnector
{
    public string Type { get; set; } = default!;
    public string Version { get; set; } = default!;
    public int Count { get; set; }
    public string Location { get; set; } = default!;

    public void Validate(List<string> errors)
    {
        Validation.String.LengthRange(errors, "USB connector type", Type, 1, 15);
        Validation.String.LengthRange(errors, "USB connector version", Version, 1, 15);
        Validation.Numeric.ValueRange(errors, "Number of USB connectors", Count, 1, 30);
        Validation.String.LengthRange(errors, "USB connector location", Location, 1, 20);
    }
}

public class FanHeader
{
    public enum PinCount : int
    {
        DC = 3,
        PWM = 4
    }

    private static readonly string PinCountDelimited = StringFormatters.DelimitEnumValues<PinCount>();

    PinCount Type { get; set; }
    public int Count { get; set; }

    public void Validate(List<string> errors)
    {
        Validation.Enum.IsInEnum(errors, "Fan connector type", (int)Type, typeof(PinCount), PinCountDelimited);
        Validation.Numeric.ValueRange(errors, "Fan connector pin count", Count, 1, 30);
    }
}
