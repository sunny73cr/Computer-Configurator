namespace ComputerConfigurator.Api.MotherboardFanHeader
{
    public class MotherboardFanHeader
    {
        public Guid MotherboardUUID { get; set; }
        public Guid FanHeaderUUID { get; set; }
        public int Count { get; set; }

        public virtual Motherboard.Motherboard Motherboard { get; set; } = null!;
        public virtual FanHeader.FanHeader FanHeader { get; set; } = null!;

        public MotherboardFanHeader()
        {

        }

        public MotherboardFanHeader(Guid motherboardUUID, DTO.Create MotherboardFanHeader)
        {
            MotherboardUUID = motherboardUUID;
            FanHeaderUUID = MotherboardFanHeader.FanHeaderUUID;
            Count = MotherboardFanHeader.Count;
        }

        public static void Edit(MotherboardFanHeader motherboardFanHeader, DTO.Edit edits)
        {
            if (motherboardFanHeader.Count != edits.Count) motherboardFanHeader.Count = edits.Count;
        }
    }
}
