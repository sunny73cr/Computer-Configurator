namespace ComputerConfigurator.Api.ChassisMotherboardFormFactorSupport.DTO
{
    public class Details
    {
        public Guid ChassisUUID { get; set; }
        public MotherboardFormFactor.DTO.Details MotherboardFormFactor { get; set; }

        public Details(ChassisMotherboardFormFactorSupport ChassisMotherboardFormFactorSupport)
        {
            ChassisUUID = ChassisMotherboardFormFactorSupport.ChassisUUID;
            MotherboardFormFactor = new MotherboardFormFactor.DTO.Details(ChassisMotherboardFormFactorSupport.MotherboardFormFactor);
        }
    }
}
