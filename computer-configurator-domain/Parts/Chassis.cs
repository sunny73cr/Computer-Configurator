//using ComputerConfigurator.Api.Domain;

//namespace ComputerConfigurator.Domain.Parts.Chassis;

//public class Chassis : Part.Details
//{
//    public static readonly Dimensions.Dimensions MaximumDimensions = new(10000, 10000, 10000);

//    public Dimensions.Dimensions Dimensions { get; set; } = default!;
//    public List<FanSupport> FanCompatibility { get; set; } = default!;
//    public List<RadiatorSupport> RadiatorCompatibility { get; set; } = default!;
//    public int MaxGPULength { get; set; }
//    public int MaxPSULength { get; set; }
//    public int MaxCPUCoolerHeight { get; set; }
//    public int ExpansionSlotCount { get; set; }
//    public int ODDBayCount { get; set; }
//    public int HDDBayCount { get; set; }
//    public int SSDBayCount { get; set; }
//    public string PSUFormFactor { get; set; } = string.Empty;
//    public List<USBPort> USBPorts { get; set; } = default!;
//    public List<AudioPort> AudioPorts { get; set; } = default!;
//    public List<Filter> Filters { get; set; } = default!;
//    public List<Motherboard.Motherboard.FormFactor> MotherboardCompatibility { get; set; } = default!;

//    public List<string> Validate()
//    {
//        List<string> errors = new();

//        //Part.Part.Validate(errors, this);

//        Dimensions.Validate(errors, "Chassis", MaximumDimensions);

//        FanCompatibility.ForEach(fanSupport => fanSupport.Validate(errors));

//        RadiatorCompatibility.ForEach(radiatorSupport => radiatorSupport.Validate(errors));

//        Validation.Numeric.ValueRange(errors, "Maximum GPU length", MaxGPULength, 150, 1000);

//        Validation.Numeric.ValueRange(errors, "Maximum PSU length", MaxPSULength, 80, 250);

//        Validation.Numeric.ValueRange(errors, "Maximum CPU cooler height", MaxCPUCoolerHeight, 50, 200);

//        Validation.Numeric.ValueRange(errors, "Number of expansion slots", ExpansionSlotCount, 0, 10);

//        Validation.Numeric.ValueRange(errors, "Number of optical bays (5.25\")", ODDBayCount, 0, 10);

//        Validation.Numeric.ValueRange(errors, "Number of hard disk bays (3.5\")", HDDBayCount, 0, 30);

//        Validation.Numeric.ValueRange(errors, "Number of solid state drive bays (2.5\")", SSDBayCount, 0, 30);

//        Validation.String.LengthRange(errors, "Power supply form factor", PSUFormFactor, 3, 20);

//        USBPorts.ForEach(usbPort => usbPort.Validate(errors));

//        AudioPorts.ForEach(audioPort => audioPort.Validate(errors));

//        Filters.ForEach(filter => filter.Validate(errors));

//        MotherboardCompatibility.ForEach(formFactor => Validation.Enum.IsInEnum(errors, "Motherboard", (int)formFactor, typeof(Motherboard.Motherboard.FormFactor), Motherboard.Motherboard.FormFactorsDelimited));

//        return errors;
//    }
//}

//public class FanSupport
//{
//    public int ChassisId { get; set; }
//    public int FanSupportId { get; set; }
//    public string Location { get; set; } = default!;
//    public List<FanSpecification> FanSpecifications { get; set; } = default!;

//    public void Validate(List<string> errors)
//    {
//        ComputerConfigurator.Api.Validation.String.LengthRange(errors, "Fan location", Location, 4, 50);

//        foreach (var fanSpecification in FanSpecifications) fanSpecification.Validate(errors);
//    }
//}

//public class FanSpecification
//{
//    public int FanSupportId { get; set; }
//    public int Diameter { get; set; }
//    public int MaximumWidth { get; set; }
//    public int Count { get; set; }

//    public void Validate(List<string> errors)
//    {
//        ComputerConfigurator.Api.Validation.Numeric.ValueOption(errors, "Fan support diameter", Diameter, Fan.Fan.Diameters, Fan.Fan.DelimitedDiameters);

//        ComputerConfigurator.Api.Validation.Numeric.ValueRange(errors, "Fan support maximum width", MaximumWidth, 10, 80);

//        ComputerConfigurator.Api.Validation.Numeric.ValueRange(errors, "Number of fans supported", Count, 1, 8);
//    }
//}

//public class RadiatorSupport
//{
//    public static readonly int[] Sizes = new[]
//{
//        120,
//        240,
//        360,
//        420
//    };

//    public static readonly string DelimitedSizes = Array.ConvertAll(
//        Sizes,
//        element => element.ToString()
//     ).Delimit();

//    public Chassis Chassis { get; set; } = default!;
//    public string Location { get; set; } = default!;
//    public List<int> SupportedSizes { get; set; } = default!;

//    public void Validate(List<string> errors)
//    {
//        Validation.String.LengthRange(errors, "Radiator location", Location, 4, 50);

//        foreach (var size in Sizes)
//        {
//            Validation.Numeric.ValueOption(errors, "Radiator size", size, Sizes, DelimitedSizes);
//        }
//    }
//}

//public class USBPort
//{
//    public Chassis Chassis { get; set; } = default!;
//    public string Type { get; set; } = default!;
//    public string Version { get; set; } = default!;
//    public int Count { get; set; }

//    public void Validate(List<string> errors)
//    {
//        Validation.String.LengthRange(errors, "USB type", Type, 1, 20);

//        Validation.String.LengthRange(errors, "USB version", Version, 1, 20);

//        Validation.Numeric.ValueRange(errors, "Number of USB ports", Count, 1, 20);
//    }
//}

//public class AudioPort
//{
//    public Chassis Chassis { get; set; } = default!;
//    public string Type { get; set; } = default!;
//    public int Count { get; set; }

//    public void Validate(List<string> errors)
//    {
//        Validation.String.LengthRange(errors, "Audio port type", Type, 1, 20);

//        Validation.Numeric.ValueRange(errors, "Number of audio ports", Count, 1, 20);
//    }
//}

//public class Filter
//{
//    public Chassis Chassis { get; set; } = default!;
//    public string Location { get; set; } = default!;
//    public bool IsRemoveable { get; set; }

//    public void Validate(List<string> errors)
//    {
//        Validation.String.LengthRange(errors, "Filter location", Location, 1, 20);
//    }
//}
