//namespace ComputerConfigurator.Domain.Parts.Storage;

//public abstract class Storage : Part.Details
//{
//    public string ConnectorType { get; } = string.Empty;
//    public int Capacity { get; }
//    public string FormFactor { get; } = string.Empty;
//    public int ReadBandwidth { get; }
//    public int WriteBandwidth { get; }
//    public int? ReadIOPS { get; }
//    public int? WriteIOPS { get; }
//    public int? MeanTimeBetweenFailure { get; }
//    public int? TerabytesWritten { get; }
//    public int? CacheSize { get; }

//    public List<string> Validate()
//    {
//        List<string> errors = new();

//        //Part.Part.Validate(errors, this);

//        Validation.String.LengthRange(errors, "Connector", ConnectorType, 1, 20);

//        Validation.Numeric.ValueRange(errors, "Capacity", Capacity, 1, 100000);

//        Validation.String.LengthRange(errors, "Form factor", FormFactor, 1, 20);

//        Validation.Numeric.ValueRange(errors, "Read bandwidth", ReadBandwidth, 1, 50000);

//        Validation.Numeric.ValueRange(errors, "Write bandwidth", WriteBandwidth, 1, 50000);

//        if (ReadIOPS != null)
//        {
//            Validation.Numeric.ValueRange(errors, "Read IOPS", (int)ReadIOPS, 1, 50000);
//        }

//        if (WriteIOPS != null)
//        {
//            Validation.Numeric.ValueRange(errors, "Write IOPS", (int)WriteIOPS, 1, 50000);
//        }

//        if (MeanTimeBetweenFailure != null)
//        {
//            Validation.Numeric.ValueRange(errors, "Mean time between failure", (int)MeanTimeBetweenFailure, 1, 10000000);
//        }

//        if (TerabytesWritten != null)
//        {
//            Validation.Numeric.ValueRange(errors, "Terabytes written", (int)TerabytesWritten, 1, 10000000);
//        }

//        if (CacheSize != null)
//        {
//            Validation.Numeric.ValueRange(errors, "Cache size", (int)CacheSize, 1, 10000000);
//        }

//        return errors;
//    }
//}

//public class HDD : Storage
//{
//    public int SpindleRPM { get; set; }

//    new public List<string> Validate()
//    {
//        List<string> errors = new();

//        errors.AddRange(base.Validate());

//        Validation.Numeric.ValueRange(errors, "Spindle RPM", SpindleRPM, 1000, 40000);

//        return errors;
//    }
//}

//public class SSD : Storage
//{
//    new public List<string> Validate()
//    {
//        List<string> errors = new();

//        errors.AddRange(base.Validate());

//        return errors;
//    }
//}

//public class NVME : Storage
//{
//    new public List<string> Validate()
//    {
//        List<string> errors = new();

//        errors.AddRange(base.Validate());

//        return errors;
//    }
//}