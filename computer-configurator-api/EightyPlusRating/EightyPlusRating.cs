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
}
