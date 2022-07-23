namespace ComputerConfigurator.DTO;

public static class StringFormatters
{
    const string delimiter = ", ";

    public static string Delimit(this string[] strings)
    {
        int listLength = strings.Length;

        string delimitedString = string.Empty;

        for (int i = 0; i < listLength; i++)
        {
            if (i == (listLength - 1)) delimitedString += strings[i];

            else delimitedString += strings[i] + delimiter;
        }

        return delimitedString;
    }

    public static string Delimit(this List<string> strings)
    {
        int listLength = strings.Count;

        string delimitedString = string.Empty;

        for (int i = 0; i < listLength; i++)
        {
            if (i == (listLength - 1)) delimitedString += strings[i];

            else delimitedString += strings[i] + delimiter;
        }

        return delimitedString;
    }

    public static string Delimit(this int[] numbers)
    {
        int numberCount = numbers.Length;

        string delimitedString = string.Empty;

        for (int i = 0; i < numberCount; i++)
        {
            if (i == (numberCount - 1)) delimitedString += numbers[i].ToString();

            else delimitedString += numbers[i].ToString() + delimiter;
        }

        return delimitedString;
    }

    public static string DelimitEnumValues<TEnum>() where TEnum : Enum
    {
        var values = Enum.GetValues(typeof(TEnum));

        string delimitedString = string.Empty;

        int valueCount = values.Length;

        for (int i = 0; i < valueCount; i++)
        {
            if (i == (valueCount - 1)) delimitedString += i.ToString();

            else delimitedString += i.ToString() + delimiter;
        }

        return delimitedString;
    }
}

