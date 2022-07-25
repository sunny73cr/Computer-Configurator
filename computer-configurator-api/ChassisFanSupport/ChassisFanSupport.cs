namespace ComputerConfigurator.Api.ChassisFanSupport
{
    public partial class ChassisFanSupport
    {
        public Guid ChassisUUID { get; set; }
        public Guid FanDiameterUUID { get; set; }
        public Guid ChassisZoneUUID { get; set; }
        public int MaximumWidthMM { get; set; }
        public int Count { get; set; }

        public virtual Chassis.Chassis Chassis { get; set; } = null!;
        public virtual FanDiameter.FanDiameter FanDiameter { get; set; } = null!;
        public virtual ChassisZone.ChassisZone ChassisZone { get; set; } = null!;

        public ChassisFanSupport()
        {

        }

        public ChassisFanSupport(Guid chassisUUID, DTO.Create ChassisFanSupport)
        {
            ChassisUUID = chassisUUID;
            FanDiameterUUID = ChassisFanSupport.FanDiameterUUID;
            ChassisZoneUUID = ChassisFanSupport.ChassisZoneUUID;
        }
    }
}
