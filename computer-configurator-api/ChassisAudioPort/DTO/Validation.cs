namespace ComputerConfigurator.Api.ChassisAudioPort.DTO
{
    public class Validation
    {
        private List<string> _errorrs = new();
        public IReadOnlyList<string> Errors { get => _errorrs.AsReadOnly(); }

        public Validation(DTO.Create chassisAudioPort)
        {

        }
    }
}
