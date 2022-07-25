namespace ComputerConfigurator.Api.ChassisAudioPort.DTO
{
    public class Details
    {
        public Guid ChassisUUID { get; set; }
        public AudioPort.DTO.Details AudioPort { get; set; }
        public ChassisZone.DTO.Details ChassisZone { get; set; }

        public Details(ChassisAudioPort chassisAudioPort)
        {
            ChassisUUID = chassisAudioPort.ChassisUUID;
            AudioPort = new AudioPort.DTO.Details(chassisAudioPort.AudioPort);
            ChassisZone = new ChassisZone.DTO.Details(chassisAudioPort.ChassisZone);
        }
    }
}
