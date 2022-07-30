namespace ComputerConfigurator.Api.EthernetPort.DTO
{
    public class Validation
    {
        private readonly List<string> _errors = new();

        public IReadOnlyList<string> Errors { get => _errors; }

        public Validation(Create EthernetPort)
        {
            DomainValidation.String.LengthRange(_errors, "Chipset", EthernetPort.Chipset, 1, 50);
            DomainValidation.Numeric.ValueRange(_errors, "Bandwidth MegaBytes", EthernetPort.BandwidthMBytes, 100, 200000);
        }
    }
}
