namespace ComputerConfigurator.Api.FanDiameter.DTO
{
    public class Details
    {
        public Guid UUID { get; set; }
        public int Diameter { get; set; }

        public Details()
        {

        }

        public Details(FanDiameter FanDiameter)
        {
            UUID = FanDiameter.UUID;
            Diameter = FanDiameter.Diameter;
        }
    }
}
