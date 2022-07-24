namespace ComputerConfigurator.Api.SATAGeneration;

public partial class SATAGeneration
{
    public Guid UUID { get; set; }
    public string Generation { get; set; } = string.Empty;

    public SATAGeneration()
    {

    }

    public SATAGeneration(DTO.Create SATAGeneration)
    {
        UUID = SATAGeneration.UUID;
        Generation = SATAGeneration.Generation;
    }

    public static void Edit(SATAGeneration SATAGeneration, DTO.Edit edits)
    {
        if (SATAGeneration.Generation != edits.Generation) SATAGeneration.Generation = edits.Generation;
    }
}
