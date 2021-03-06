namespace ComputerConfigurator.Api.AudioPort
{
    public partial class AudioPort
    {
        public Guid UUID { get; set; }
        public int PinCount { get; set; }
        public float ConnectorSize { get; set; }

        public AudioPort()
        {

        }

        public AudioPort(DTO.Create audioPort)
        {
            UUID = audioPort.UUID;
            PinCount = audioPort.PinCount;
            ConnectorSize = audioPort.ConnectorSize;
        }
    }
}
