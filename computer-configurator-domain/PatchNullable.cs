namespace ComputerConfigurator.Domain;

public class PatchNullable<TValue>
{
    public bool SetNull { get; set; } = false;
    public TValue? Value { get; set; } = default(TValue);
    //if not setting null, value must not be null.
    public bool IsValidPatch()
    {
        if (SetNull) return true;

        bool IsDefault = EqualityComparer<TValue>.Default.Equals(Value, default(TValue));
        if (IsDefault == false) return true;

        return false;
    }
}

