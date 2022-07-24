namespace ComputerConfigurator.Api.PCIEGeneration.DTO
{
    public class Details
    {
        public Guid UUID { get; set; }
        public string Generation { get; set; } = string.Empty;

        public Details()
        {

        }

        public Details(PCIEGeneration PCIEGeneration)
        {
            UUID = PCIEGeneration.UUID;
            Generation = PCIEGeneration.Generation;
        }
    }
}
