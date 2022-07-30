namespace ComputerConfigurator.Api.EightyPlusRating.DTO
{
    public class Validation
    {
        private readonly List<string> _errors = new();

        public IReadOnlyList<string> Errors { get => _errors; }

        public Validation(Create EightyPlusRating)
        {
            DomainValidation.String.LengthRange(_errors, "Rating", EightyPlusRating.Rating, 1, 20);
        }
    }
}
