namespace ComputerConfigurator.Api.EightyPlusRating.DTO
{
    public class Details
    {
        public Guid UUID { get; set; }
        public string Rating { get; set; } = string.Empty;

        public Details()
        {

        }

        public Details(EightyPlusRating EightyPlusRating)
        {
            UUID = EightyPlusRating.UUID;
            Rating = EightyPlusRating.Rating;
        }
    }
}
