namespace ComputerConfigurator.Api.MotherboardDisplayConnector
{
    public class MotherboardDisplayConnector
    {
        public Guid MotherboardUUID { get; set; }
        public Guid DisplayConnectorUUID { get; set; }
        public int Count { get; set; }

        public virtual Motherboard.Motherboard Motherboard { get; set; } = null!;
        public virtual DisplayConnector.DisplayConnector DisplayConnector { get; set; } = null!;

        public MotherboardDisplayConnector()
        {

        }

        public MotherboardDisplayConnector(Guid motherboardUUID, DTO.Create MotherboardDisplayConnector)
        {
            MotherboardUUID = motherboardUUID;
            DisplayConnectorUUID = MotherboardDisplayConnector.DisplayConnectorUUID;
            Count = MotherboardDisplayConnector.Count;
        }

        public static void Edit(MotherboardDisplayConnector motherboardDisplayConnector, DTO.Edit edits)
        {
            if (motherboardDisplayConnector.Count != edits.Count) motherboardDisplayConnector.Count = edits.Count;
        }
    }
}
