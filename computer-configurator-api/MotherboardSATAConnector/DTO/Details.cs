namespace ComputerConfigurator.Api.MotherboardSATAConnector.DTO
{
    public class Details
    {
        public SATAGeneration.DTO.Details SATAGeneration { get; set; }
        public int Count { get; set; }

        public Details(MotherboardSATAConnector MotherboardSATAConnector)
        {
            SATAGeneration = new SATAGeneration.DTO.Details(MotherboardSATAConnector.SATAGeneration);
            Count = MotherboardSATAConnector.Count;
        }
    }
}
