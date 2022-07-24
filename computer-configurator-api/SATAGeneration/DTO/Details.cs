namespace ComputerConfigurator.Api.SATAGeneration.DTO
{
    public class Details
    {
        public Guid UUID { get; set; }
        public string Generation { get; set; } = string.Empty;

        public Details()
        {

        }

        public Details(SATAGeneration SATAGeneration)
        {
            UUID = SATAGeneration.UUID;
            Generation = SATAGeneration.Generation;
        }
    }
}
