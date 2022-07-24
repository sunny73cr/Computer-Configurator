namespace ComputerConfigurator.Api.RAIDMode.DTO
{
    public class Details
    {
        public Guid UUID { get; set; }
        public string Mode { get; set; } = string.Empty;

        public Details()
        {

        }

        public Details(RAIDMode RAIDMode)
        {
            UUID = RAIDMode.UUID;
            Mode = RAIDMode.Mode;
        }
    }
}
