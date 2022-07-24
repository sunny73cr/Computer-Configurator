namespace ComputerConfigurator.Api.MotherboardFormFactor.DTO
{
    public class Details
    {
        public Guid UUID { get; set; }
        public string FormFactor { get; set; } = string.Empty;

        public Details()
        {

        }

        public Details(MotherboardFormFactor MotherboardFormFactor)
        {
            UUID = MotherboardFormFactor.UUID;
            FormFactor = MotherboardFormFactor.FormFactor;
        }
    }
}
