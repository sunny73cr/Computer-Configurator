namespace ComputerConfigurator.Api.ChassisRadiatorSupport.DTO
{
    public class Details
    {
        public RadiatorSize.DTO.Details RadiatorSize { get; set; }
        public ChassisZone.DTO.Details ChassisZone { get; set; }
        public int MaximumWidthMM { get; set; }

        public Details(ChassisRadiatorSupport ChassisRadiatorSupport)
        {
            RadiatorSize = new RadiatorSize.DTO.Details(ChassisRadiatorSupport.RadiatorSize);
            ChassisZone = new ChassisZone.DTO.Details(ChassisRadiatorSupport.ChassisZone);
            MaximumWidthMM = ChassisRadiatorSupport.MaximumWidthMM;
        }
    }
}
