namespace ComputerConfigurator.Api.ChassisFanSupport.DTO
{
    public class Details
    {
        public FanDiameter.DTO.Details FanDiameter { get; set; }
        public ChassisZone.DTO.Details ChassisZone { get; set; }
        public int MaximumWidthMM { get; set; }
        public int Count { get; set; }

        public Details(ChassisFanSupport ChassisFanSupport)
        {
            FanDiameter = new FanDiameter.DTO.Details(ChassisFanSupport.FanDiameter);
            ChassisZone = new ChassisZone.DTO.Details(ChassisFanSupport.ChassisZone);
            MaximumWidthMM = ChassisFanSupport.MaximumWidthMM;
            Count = ChassisFanSupport.Count;
        }
    }
}
