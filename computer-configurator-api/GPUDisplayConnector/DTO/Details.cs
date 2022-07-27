namespace ComputerConfigurator.Api.GPUDisplayConnector.DTO
{
    public class Details
    {
        public Guid GPUUUID { get; set; }
        public DisplayConnector.DTO.Details DisplayConnector { get; set; }
        public int Count { get; set; }

        public Details(GPUDisplayConnector gpuDisplayConnector)
        {
            GPUUUID = gpuDisplayConnector.GPUUUID;
            DisplayConnector = new DisplayConnector.DTO.Details(gpuDisplayConnector.DisplayConnector);
            Count = gpuDisplayConnector.Count;
        }
    }
}
