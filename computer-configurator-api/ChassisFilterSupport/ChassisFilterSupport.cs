namespace ComputerConfigurator.Api.ChassisFilterSupport
{
    public partial class ChassisFilterSupport
    {
        public Guid ChassisUUID { get; set; }
        public Guid ChassisZoneUUID { get; set; }
        public bool Removeable { get; set; }

        public virtual Chassis.Chassis Chassis { get; set; } = null!;
        public virtual ChassisZone.ChassisZone ChassisZone { get; set; } = null!;

        public ChassisFilterSupport()
        {

        }

        public ChassisFilterSupport(Guid chassisUUID, DTO.Create ChassisAudioPort)
        {
            ChassisUUID = chassisUUID;
            ChassisZoneUUID = ChassisAudioPort.ChassisZoneUUID;
            Removeable = ChassisAudioPort.Removeable;
        }
    }
}
