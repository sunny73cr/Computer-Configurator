namespace ComputerConfigurator.Api.MotherboardSATAConnector
{
    public class MotherboardSATAConnector
    {
        public Guid MotherboardUUID { get; set; }
        public Guid SATAGenerationUUID { get; set; }
        public int Count { get; set; }

        public virtual Motherboard.Motherboard Motherboard { get; set; } = null!;
        public virtual SATAGeneration.SATAGeneration SATAGeneration { get; set; } = null!;

        public MotherboardSATAConnector()
        {

        }

        public MotherboardSATAConnector(Guid motherboardUUID, DTO.Create MotherboardSATAConnector)
        {
            MotherboardUUID = motherboardUUID;
            SATAGenerationUUID = MotherboardSATAConnector.SATAGenerationUUID;
            Count = MotherboardSATAConnector.Count;
        }

        public static void Edit(MotherboardSATAConnector MotherboardSATAConnector, DTO.Edit edits)
        {
            if (MotherboardSATAConnector.Count != edits.Count) MotherboardSATAConnector.Count = edits.Count;
        }
    }
}
