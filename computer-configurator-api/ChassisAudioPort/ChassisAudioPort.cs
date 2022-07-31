namespace ComputerConfigurator.Api.ChassisAudioPort
{
    public partial class ChassisAudioPort
    {
        public Guid ChassisUUID { get; set; }
        public Guid AudioPortUUID { get; set; }
        public Guid ChassisZoneUUID { get; set; }

        public virtual Chassis.Chassis Chassis { get; set; } = null!;
        public virtual AudioPort.AudioPort AudioPort { get; set; } = null!;
        public virtual ChassisZone.ChassisZone ChassisZone { get; set; } = null!;

        public ChassisAudioPort()
        {

        }

        public ChassisAudioPort(Guid chassisUUID, DTO.Create chassisAudioPort)
        {
            ChassisUUID = chassisUUID;
            AudioPortUUID = chassisAudioPort.AudioPortUUID;
            ChassisZoneUUID = chassisAudioPort.ChassisZoneUUID;
        }
    }
}
