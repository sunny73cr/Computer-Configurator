namespace ComputerConfigurator.Api.ChassisMotherboardFormFactorSupport.DTO
{
    public class Details
    {
        public MotherboardFormFactor.DTO.Details MotherboardFormFactor { get; set; }

        public Details(ChassisMotherboardFormFactorSupport ChassisMotherboardFormFactorSupport)
        {
            MotherboardFormFactor = new MotherboardFormFactor.DTO.Details(ChassisMotherboardFormFactorSupport.MotherboardFormFactor);
        }
    }
}
