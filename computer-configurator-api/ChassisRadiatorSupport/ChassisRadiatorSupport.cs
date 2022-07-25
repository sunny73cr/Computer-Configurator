namespace ComputerConfigurator.Api.ChassisRadiatorSupport
{
    public partial class ChassisRadiatorSupport
    {
        public Guid ChassisUUID { get; set; }
        public Guid RadiatorSizeUUID { get; set; }
        public Guid ChassisZoneUUID { get; set; }
        public int MaximumWidthMM { get; set; }

        public virtual Chassis.Chassis Chassis { get; set; } = null!;
        public virtual RadiatorSize.RadiatorSize RadiatorSize {get; set;} = null!;
        public virtual ChassisZone.ChassisZone ChassisZone { get; set; } = null!;

        public ChassisRadiatorSupport()
        {

        }

        public ChassisRadiatorSupport(Guid chassisUUID, DTO.Create ChassisRadiatorSupport)
        {
            ChassisUUID = chassisUUID;
            RadiatorSizeUUID = ChassisRadiatorSupport.RadiatorSizeUUID;
            ChassisZoneUUID = ChassisRadiatorSupport.ChassisZoneUUID;
            MaximumWidthMM = ChassisRadiatorSupport.MaximumWidthMM;
        }
    }
}
