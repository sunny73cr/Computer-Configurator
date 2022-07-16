namespace ComputerConfigurator.Domain.Parts.CPU;

public enum SocketType
{
    LGA1155 = 0,
    LGA1151 = 1,
    LGA1150 = 2,
    LGA1200 = 3,
    LGA1700 = 4,
    AM3 = 5,
    AM3Plus = 6,
    AM4 = 7,
    AM5 = 8
}

public class Create : Part.Create
{
    public SocketType SocketType { get; set; }
    public int CoreCount { get; set; }
    public int ThreadCount { get; set; }
    public int BaseClockSpeed { get; set; }
    public int? BoostClockSpeed { get; set; }

    public List<string> Validate()
    {
        List<string> errors = new();

        //Validation.Enum.IsInEnum(errors, "Socket type", (int)SocketType, typeof(SocketType), StringFormatters.DelimitEnumValues<SocketType>());

        Validation.Numeric.ValueRange(errors, "Core count", CoreCount, 1, 512);

        Validation.Numeric.ValueRange(errors, "Thread count", ThreadCount, 1, 1024);

        Validation.Numeric.ValueRange(errors, "Base clock speed", BaseClockSpeed, 800, 7000);

        if (BoostClockSpeed != null)
            Validation.Numeric.ValueRange(errors, "Boost clock speed", (int)BoostClockSpeed, 800, 10000);

        return errors;
    }
}

public class Details : Part.Details
{
    public SocketType SocketType { get; }
    public int CoreCount { get; }
    public int ThreadCount { get; }
    public int BaseClockSpeed { get; }
    public int? BoostClockSpeed { get; }
}

public class Edit : Part.Edit
{
    public SocketType? SocketType { get; set; }
    public int? CoreCount { get; set; }
    public int? ThreadCount { get; set; }
    public int? BaseClockSpeed { get; set; }
    public PatchNullable<int?>? BoostClockSpeed { get; set; }

    public new bool HasEdits()
    {
        if (base.HasEdits()) return true;

        return
            SocketType != null ||
            CoreCount != null ||
            ThreadCount != null ||
            BaseClockSpeed != null ||
            BoostClockSpeed != null;
    }

    public List<string> Validate()
    {
        List<string> errors = new();

        Part.Edit.Validate(errors, this);

        //if (SocketType != null)
        //    Validation.Enum.IsInEnum(errors, "Socket type", (int)SocketType, typeof(SocketType), StringFormatters.DelimitEnumValues<SocketType>());

        if (CoreCount != null)
            Validation.Numeric.ValueRange(errors, "Core count", (int)CoreCount, 1, 512);

        if (ThreadCount != null)
            Validation.Numeric.ValueRange(errors, "Thread count", (int)ThreadCount, 1, 1024);

        if (BaseClockSpeed != null)
            Validation.Numeric.ValueRange(errors, "Base clock speed", (int)BaseClockSpeed, 800, 7000);

        //there is a patch spec present, the value is not being set to null, and there is a value to set.
        if (BoostClockSpeed != null && BoostClockSpeed.SetNull == false && BoostClockSpeed.Value != null)
            Validation.Numeric.ValueRange(errors, "Boost clock speed", (int)BoostClockSpeed.Value, 800, 10000);

        return errors;
    }
}