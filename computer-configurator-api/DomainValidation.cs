namespace ComputerConfigurator.DomainValidation;

public static class Output
{
    public static string Format(List<string> errors)
    {
        string errorMessage = string.Empty;

        foreach (var error in errors)
        {
            errorMessage += error + '\n';
        }

        return errorMessage;
    }
}

public static class Enum
{
    private static string EnumError(string propertyName, string input, string delimitedOptions)
    {
        return $"{propertyName}: \'{input}\' is not a valid option. Expected one of: {delimitedOptions}.";
    }
    public static void IsInEnum(List<string> errors, string propertyName, string input, Type enumType, string delimitedOptions)
    {
        //Throws ArgumentException if enumType is not an enum.
        if (enumType.IsEnumDefined(input)) errors.Add(EnumError(propertyName, input, delimitedOptions));
    }
    public static void IsInEnum(List<string> errors, string propertyName, int input, Type enumType, string delimitedOptions)
    {
        //Throws ArgumentException if enumType is not an enum.
        if (enumType.IsEnumDefined(input)) errors.Add(EnumError(propertyName, input.ToString(), delimitedOptions));
    }
}

public static class String
{
    public static void MinimumLength(List<string> errors, string propertyName, string input, int length)
    {
        if (input.Length < length) errors.Add($"{propertyName}: \'{input}\' must be {length} characters or more.");
    }
    public static void MaximumLength(List<string> errors, string propertyName, string input, int length)
    {
        if (input.Length > length) errors.Add($"{propertyName}: \'{input}\' must be {length} characters or less.");
    }

    public static void ExactLength(List<string> errors, string propertyName, string input, int length)
    {
        if (input.Length != length) errors.Add($"{propertyName}: \'{input}\' must be {length} characters.");
    }
    public static void LengthRange(List<string> errors, string propertyName, string input, int lowerBound, int upperBound)
    {
        if (input.Length < lowerBound || input.Length > upperBound) errors.Add($"{propertyName}: \'{input}\' must be between {lowerBound} and {upperBound} characters.");
    }

    //Value option
    private static string ValueOptionError(string propertyName, string input, string delimitedOptions)
    {
        return $"{propertyName}: \'{input}\' is not a valid option. Expected one of: {delimitedOptions}.";
    }
    public static void ValueOption(List<string> errors, string propertyName, string input, string[] options, string delimitedOptions)
    {
        if (options.Contains(input) == false) errors.Add(ValueOptionError(propertyName, input, delimitedOptions));
    }

    public static void IsBase64Encoded(List<string> errors, string propertyName, string input)
    {
        bool valid = Convert.TryFromBase64String(input, new Span<byte>(), out _);

        if (!valid) errors.Add($"\'{propertyName}\' is not a valid Base64 encoded string.");
    }
}

public static class Numeric
{
    //Minimum value
    private static string MinimumValueError(string propertyName, string input, string lowerBound)
    {
        return $"{propertyName}: \'{input}\' must be {lowerBound} or more.";
    }
    public static void MinimumValue(List<string> errors, string propertyName, int input, int lowerBound)
    {
        if (input < lowerBound) errors.Add(MinimumValueError(propertyName, input.ToString(), lowerBound.ToString()));
    }
    public static void MinimumValue(List<string> errors, string propertyName, decimal input, decimal lowerBound)
    {
        if (input < lowerBound) errors.Add(MinimumValueError(propertyName, input.ToString(), lowerBound.ToString()));
    }
    public static void MinimumValue(List<string> errors, string propertyName, float input, float lowerBound)
    {
        if (input < lowerBound) errors.Add(MinimumValueError(propertyName, input.ToString(), lowerBound.ToString()));
    }

    //Maximum value
    private static string MaximumValueError(string propertyName, string input, string upperBound)
    {
        return $"{propertyName}: \'{input}\' must be {upperBound} or less.";
    }
    public static void MaximumValue(List<string> errors, string propertyName, int input, int upperBound)
    {
        if (input > upperBound) errors.Add(MaximumValueError(propertyName, input.ToString(), upperBound.ToString()));
    }
    public static void MaximumValue(List<string> errors, string propertyName, decimal input, decimal upperBound)
    {
        if (input > upperBound) errors.Add(MaximumValueError(propertyName, input.ToString(), upperBound.ToString()));
    }
    public static void MaximumValue(List<string> errors, string propertyName, float input, float upperBound)
    {
        if (input > upperBound) errors.Add(MaximumValueError(propertyName, input.ToString(), upperBound.ToString()));
    }

    //Value range
    private static string ValueRangeError(string propertyName, string input, string lowerBound, string upperBound)
    {
        return $"{propertyName}: \'{input}\' must be between {lowerBound} and {upperBound}.";
    }
    public static void ValueRange(List<string> errors, string propertyName, int input, int lowerBound, int upperBound)
    {
        if (input < lowerBound || input > upperBound) errors.Add(ValueRangeError(propertyName, input.ToString(), lowerBound.ToString(), upperBound.ToString()));
    }
    public static void ValueRange(List<string> errors, string propertyName, decimal input, decimal lowerBound, decimal upperBound)
    {
        if (input < lowerBound || input > upperBound) errors.Add(ValueRangeError(propertyName, input.ToString(), lowerBound.ToString(), upperBound.ToString()));
    }
    public static void ValueRange(List<string> errors, string propertyName, float input, float lowerBound, float upperBound)
    {
        if (input < lowerBound || input > upperBound) errors.Add(ValueRangeError(propertyName, input.ToString(), lowerBound.ToString(), upperBound.ToString()));
    }

    //Value option
    private static string ValueOptionError(string propertyName, string input, string delimitedOptions)
    {
        return $"{propertyName}: \'{input}\' is not a valid option. Expected one of: {delimitedOptions}.";
    }
    public static void ValueOption(List<string> errors, string propertyName, int input, int[] options, string delimitedOptions)
    {
        if (options.Contains(input) == false) errors.Add(ValueOptionError(propertyName, input.ToString(), delimitedOptions));
    }
}

public static class Guid
{
    public static void NotEmpty(List<string> errors, string propertyName, System.Guid input)
    {
        if (System.Guid.Empty.Equals(input)) errors.Add($"{propertyName} must not be empty.");
    }
}
