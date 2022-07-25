namespace ComputerConfigurator.Api.ChassisFilterSupport.DTO
{
    public class Details
    {
        public Guid ChassisUUID { get; set; }
        public ChassisZone.DTO.Details ChassisZone { get; set; }
        public bool Removeable { get; set; }

        public Details(ChassisFilterSupport ChassisFilterSupport)
        {
            ChassisUUID = ChassisFilterSupport.ChassisUUID;
            ChassisZone = new ChassisZone.DTO.Details(ChassisFilterSupport.ChassisZone);
            Removeable = ChassisFilterSupport.Removeable;
        }
    }
}
