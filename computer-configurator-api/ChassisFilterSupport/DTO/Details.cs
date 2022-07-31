namespace ComputerConfigurator.Api.ChassisFilterSupport.DTO
{
    public class Details
    {
        public ChassisZone.DTO.Details ChassisZone { get; set; }
        public bool Removeable { get; set; }

        public Details(ChassisFilterSupport ChassisFilterSupport)
        {
            ChassisZone = new ChassisZone.DTO.Details(ChassisFilterSupport.ChassisZone);
            Removeable = ChassisFilterSupport.Removeable;
        }
    }
}
