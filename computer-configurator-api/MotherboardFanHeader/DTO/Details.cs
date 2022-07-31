namespace ComputerConfigurator.Api.MotherboardFanHeader.DTO
{
    public class Details
    {
        public FanHeader.DTO.Details FanHeader { get; set; }
        public int Count { get; set; }

        public Details(MotherboardFanHeader MotherboardFanHeader)
        {
            FanHeader = new FanHeader.DTO.Details(MotherboardFanHeader.FanHeader);
            Count = MotherboardFanHeader.Count;
        }
    }
}
