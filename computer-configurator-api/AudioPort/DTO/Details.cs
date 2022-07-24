namespace ComputerConfigurator.Api.AudioPort.DTO
{
    public class Details
    {
        public Guid UUID { get; set; }
        public int PinCount { get; set; }
        public float ConnectorSize { get; set; }

        public Details()
        {

        }

        public Details(AudioPort audioPort)
        {
            UUID = audioPort.UUID;
            PinCount = audioPort.PinCount;
            ConnectorSize = audioPort.ConnectorSize;
        }
    }
}
