//namespace ComputerConfigurator.Domain.Parts.RAM;

//public class RAM : Part.Details
//{
//    public string SocketType { get; } = default!;
//    public int ModuleCapacity { get; }
//    public int DIMMCount { get; }
//    public int RAMClockRate { get; }
//    public int CasLatency { get; }
//    public int Trcd { get; }
//    public int Trp { get; }
//    public int Tras { get; }

//    public List<string> Validate()
//    {
//        List<string> errors = new();

//        //Part.Part.Validate(errors, this);

//        Validation.String.LengthRange(errors, "Socket type", SocketType, 3, 10);

//        Validation.Numeric.ValueRange(errors, "Capacity", ModuleCapacity, 1, 1024);

//        Validation.Numeric.ValueRange(errors, "Number of DIMMs", DIMMCount, 1, 16);

//        Validation.Numeric.ValueRange(errors, "RAM clock rate", RAMClockRate, 800, 10000);

//        Validation.Numeric.ValueRange(errors, "CAS latency", CasLatency, 1, 60);

//        Validation.Numeric.ValueRange(errors, "tRCD", Trcd, 1, 60);

//        Validation.Numeric.ValueRange(errors, "tRP", Trp, 1, 60);

//        Validation.Numeric.ValueRange(errors, "tRP", Tras, 1, 120);

//        return errors;
//    }
//}
