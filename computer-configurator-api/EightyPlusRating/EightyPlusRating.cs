namespace ComputerConfigurator.Api.EightyPlusRating;

public partial class EightyPlusRating
{
    public Guid UUID { get; set; }
    public string Rating { get; set; } = string.Empty;

    public EightyPlusRating()
    {

    }

    public EightyPlusRating(DTO.Create EightyPlusRating)
    {
        UUID = EightyPlusRating.UUID;
        Rating = EightyPlusRating.Rating;
    }

    public static void Edit(EightyPlusRating EightyPlusRating, DTO.Edit edits)
    {
        if (EightyPlusRating.Rating != edits.Rating) EightyPlusRating.Rating = edits.Rating;
    }
}
