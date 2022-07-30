namespace ComputerConfigurator.Api.ChassisZone.DTO
{
    public class Validation
    {
        private readonly List<string> _errors = new();

        public IReadOnlyList<string> Errors { get => _errors; }

        public Validation(Create ChassisZone)
        {
            DomainValidation.String.LengthRange(_errors, "Zone", ChassisZone.Zone, 1, 50);
        }
    }
}
