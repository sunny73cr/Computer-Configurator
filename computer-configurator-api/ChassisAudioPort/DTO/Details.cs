namespace ComputerConfigurator.Api.ChassisAudioPort.DTO
{
    public class Details
    {
        public AudioPort.DTO.Details AudioPort { get; set; }
        public ChassisZone.DTO.Details ChassisZone { get; set; }

        public Details(ChassisAudioPort chassisAudioPort)
        {
            AudioPort = new AudioPort.DTO.Details(chassisAudioPort.AudioPort);
            ChassisZone = new ChassisZone.DTO.Details(chassisAudioPort.ChassisZone);
        }
    }
}
