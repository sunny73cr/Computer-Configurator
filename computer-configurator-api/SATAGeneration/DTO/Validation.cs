namespace ComputerConfigurator.Api.SATAGeneration.DTO
{
    public class Validation
    {
        private readonly List<string> _errors = new();

        public IReadOnlyList<string> Errors { get => _errors; }

        public Validation(Create SATAGeneration)
        {
            DomainValidation.String.LengthRange(_errors, "Generation", SATAGeneration.Generation, 1, 10);
        }

        public Validation(Edit SATAGeneration)
        {
            DomainValidation.String.LengthRange(_errors, "Generation", SATAGeneration.Generation, 1, 10);
        }
    }
}
