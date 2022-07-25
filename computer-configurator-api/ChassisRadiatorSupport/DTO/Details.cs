namespace ComputerConfigurator.Api.ChassisRadiatorSupport.DTO
{
    public class Details
    {
        public Guid ChassisUUID { get; set; }
        public RadiatorSize.DTO.Details RadiatorSize { get; set; }
        public ChassisZone.DTO.Details ChassisZone { get; set; }
        public int MaximumWidthMM { get; set; }

        public Details(ChassisRadiatorSupport ChassisRadiatorSupport)
        {
            ChassisUUID = ChassisRadiatorSupport.ChassisUUID;
            RadiatorSize = new RadiatorSize.DTO.Details(ChassisRadiatorSupport.RadiatorSize);
            ChassisZone = new ChassisZone.DTO.Details(ChassisRadiatorSupport.ChassisZone);
            MaximumWidthMM = ChassisRadiatorSupport.MaximumWidthMM;
        }
    }
}
