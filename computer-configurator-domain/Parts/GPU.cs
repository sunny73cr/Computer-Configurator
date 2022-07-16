//namespace ComputerConfigurator.Domain.Parts.GPU;

//public class GPU : Part.Details
//{
//    public static readonly Dimensions.Dimensions MaximumDimensions = new(500, 100, 200);

//    public string PCIEInterface { get; set; } = default!;
//    public int PCIEVersion { get; set; }
//    public float VRAMCapacity { get; set; }
//    public int BaseClockSpeed { get; set; }
//    public int? BoostClockSpeed { get; set; }
//    public List<DisplayConnector> DisplayConnectors { get; set; } = default!;
//    public int MaxDisplayCount { get; set; }
//    public Dimensions.Dimensions Dimensions { get; set; } = default!;
//    public int SlotWidth { get; set; }

//    public List<string> Validate()
//    {
//        List<string> errors = new();

//        //Part.Part.Validate(errors, this);

//        Validation.String.LengthRange(errors, "PCIE Interface", PCIEInterface, 1, 6);

//        Validation.Numeric.ValueRange(errors, "PCIE version", PCIEVersion, 1, 6);

//        Validation.Numeric.ValueRange(errors, "VRAM capacity", VRAMCapacity, 128, 131072);

//        Validation.Numeric.ValueRange(errors, "Base clock speed", BaseClockSpeed, 200, 5000);

//        if (BoostClockSpeed != null)
//        {
//            Validation.Numeric.ValueRange(errors, "Boost clock speed", (int)BoostClockSpeed, 200, 5000);

//            if (BoostClockSpeed < BaseClockSpeed)
//            {
//                errors.Add("Boost clock speed must be greater than the base clock speed.");
//            }
//        }

//        DisplayConnectors.ForEach(connector => connector.Validate(errors));

//        Validation.Numeric.ValueRange(errors, "Maximum display count", MaxDisplayCount, 0, 10);

//        Dimensions.Validate(errors, "GPU", MaximumDimensions);

//        Validation.Numeric.ValueRange(errors, "Slot width", SlotWidth, 1, 4);

//        return errors;
//    }
//}

//public class DisplayConnector
//{
//    public GPU GPU { get; set; } = default!;
//    public string Type { get; set; } = default!;
//    public string Version { get; set; } = default!;
//    public int Count { get; set; }

//    public void Validate(List<string> errors)
//    {
//        Validation.String.LengthRange(errors, "Display connector type", Type, 1, 30);

//        Validation.String.LengthRange(errors, "Display connector version", Version, 1, 30);

//        Validation.Numeric.ValueRange(errors, "Display connector count", Count, 1, 5);
//    }
//}