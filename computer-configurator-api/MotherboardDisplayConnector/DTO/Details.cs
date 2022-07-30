namespace ComputerConfigurator.Api.MotherboardDisplayConnector.DTO
{
    public class Details
    {
        public DisplayConnector.DTO.Details DisplayConnector { get; set; }
        public int Count { get; set; }

        public Details(MotherboardDisplayConnector motherboardDisplayConnector)
        {
            DisplayConnector = new DisplayConnector.DTO.Details(motherboardDisplayConnector.DisplayConnector);
            Count = motherboardDisplayConnector.Count;
        }
    }
}
