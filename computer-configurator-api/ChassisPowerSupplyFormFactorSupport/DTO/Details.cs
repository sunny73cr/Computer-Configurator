namespace ComputerConfigurator.Api.ChassisPowerSupplyFormFactorSupport.DTO
{
    public class Details
    {
        public PowerSupplyFormFactor.DTO.Details PowerSupplyFormFactor { get; set; }
        public bool Removeable { get; set; }

        public Details(ChassisPowerSupplyFormFactorSupport ChassisPowerSupplyFormFactorSupport)
        {
            PowerSupplyFormFactor = new PowerSupplyFormFactor.DTO.Details(ChassisPowerSupplyFormFactorSupport.PowerSupplyFormFactor);
            Removeable = ChassisPowerSupplyFormFactorSupport.BracketRequired;
        }
    }
}
