namespace ComputerConfigurator.Domain.Parts.Part;

public abstract class Details
{
    public int Id { get; }
    public DateTime CreatedTimestamp { get; }
    public string Manufacturer { get; } = string.Empty;
    public string Model { get; } = string.Empty;
    public string ShortDescription { get; } = string.Empty;
    public string? LongDescription { get; }
    public decimal Price { get; }
}

public abstract class Create
{
    public string Manufacturer { get; set; } = default!;
    public string Model { get; set; } = default!;
    public string? LongDescription { get; set; } = null;
    public decimal Price { get; set; }

    public static void Validate(List<string> errors, Create part)
    {
        Validation.String.LengthRange(errors, "Manufacturer", part.Manufacturer, 1, 50);

        Validation.String.LengthRange(errors, "Model", part.Model, 1, 50);

        if (part.LongDescription != null)
            Validation.String.LengthRange(errors, "Long description", part.LongDescription, 1, 200);

        Validation.Numeric.ValueRange(errors, "Price", part.Price, 0M, 100000M);
    }
}

public abstract class Edit
{
    public string? Manufacturer { get; set; }
    public string? Model { get; set; }
    public PatchNullable<string?>? LongDescription { get; set; }
    public decimal? Price { get; set; }

    protected bool HasEdits()
    {
        return
            Manufacturer != null ||
            Model != null ||
            LongDescription != null ||
            Price != null;
    }

    protected static void Validate(List<string> errors, Edit edits)
    {
        if (edits.Manufacturer != null)
            Validation.String.LengthRange(errors, "Manufacturer", edits.Manufacturer, 1, 50);

        if (edits.Model != null)
            Validation.String.LengthRange(errors, "Model", edits.Model, 1, 50);

        if (edits.LongDescription != null && edits.LongDescription.SetNull == false && edits.LongDescription != null)
            Validation.String.LengthRange(errors, "Long description", edits.LongDescription.Value!, 1, 200);

        if (edits.Price != null)
            Validation.Numeric.ValueRange(errors, "Price", (decimal)edits.Price, 0M, 100000M);
    }
}