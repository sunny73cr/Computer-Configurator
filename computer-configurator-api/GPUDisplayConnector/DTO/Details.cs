namespace ComputerConfigurator.Api.GPUDisplayConnector.DTO
{
    public class Details
    {
        public DisplayConnector.DTO.Details DisplayConnector { get; set; }
        public int Count { get; set; }

        public Details(GPUDisplayConnector gpuDisplayConnector)
        {
            DisplayConnector = new DisplayConnector.DTO.Details(gpuDisplayConnector.DisplayConnector);
            Count = gpuDisplayConnector.Count;
        }
    }
}
