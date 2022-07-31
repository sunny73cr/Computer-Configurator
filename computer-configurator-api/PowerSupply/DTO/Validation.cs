namespace ComputerConfigurator.Api.PowerSupply.DTO
{
    public class Validation
    {
        private readonly List<string> _errors = new();
        public IReadOnlyList<string> Errors { get => _errors.AsReadOnly(); }

        public Validation(DTO.Create powerSupply)
        {
            _errors.AddRange(new Api.Part.DTO.Validation(powerSupply).Errors);
        }

        public Validation(DTO.Edit powerSupply)
        {
            _errors.AddRange(new Api.Part.DTO.Validation(powerSupply).Errors);
        }
    }
}
