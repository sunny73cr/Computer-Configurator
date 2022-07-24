namespace ComputerConfigurator.Api.PowerSupplyFormFactor.DTO
{
    public class Details
    {
        public Guid UUID { get; set; }
        public string FormFactor { get; set; } = string.Empty;

        public Details()
        {

        }

        public Details(PowerSupplyFormFactor PowerSupplyFormFactor)
        {
            UUID = PowerSupplyFormFactor.UUID;
            FormFactor = PowerSupplyFormFactor.FormFactor;
        }
    }
}
