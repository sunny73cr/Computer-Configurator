namespace ComputerConfigurator.Api.PCIEConnector.DTO
{
    public class Validation
    {
        private readonly List<string> _errors = new();

        public IReadOnlyList<string> Errors { get => _errors; }

        public Validation(Create PCIEConnector)
        {
            DomainValidation.Numeric.ValueRange(_errors, "Lane count", PCIEConnector.LaneCount, 1, 16);
        }

        public Validation(Edit PCIEConnector)
        {
            DomainValidation.Numeric.ValueRange(_errors, "Lane count", PCIEConnector.LaneCount, 1, 16);
        }
    }
}
