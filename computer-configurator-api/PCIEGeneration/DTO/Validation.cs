namespace ComputerConfigurator.Api.PCIEGeneration.DTO
{
    public class Validation
    {
        private readonly List<string> _errors = new();

        public IReadOnlyList<string> Errors { get => _errors; }

        public Validation(Create PCIEGeneration)
        {
            DomainValidation.String.LengthRange(_errors, "Generation", PCIEGeneration.Generation, 1, 16);
        }

        public Validation(Edit PCIEGeneration)
        {
            DomainValidation.String.LengthRange(_errors, "Generation", PCIEGeneration.Generation, 1, 16);
        }
    }
}
