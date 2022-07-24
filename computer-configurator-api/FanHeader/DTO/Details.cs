namespace ComputerConfigurator.Api.FanHeader.DTO
{
    public class Details
    {
        public Guid UUID { get; set; }
        public int PinCount { get; set; }

        public Details()
        {

        }

        public Details(FanHeader FanHeader)
        {
            UUID = FanHeader.UUID;
            PinCount = FanHeader.PinCount;
        }
    }
}
