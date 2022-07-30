namespace ComputerConfigurator.Api.GPUDisplayConnector
{
    public class GPUDisplayConnector
    {
        public Guid GPUUUID { get; set; }
        public Guid DisplayConnectorUUID { get; set; }
        public int Count { get; set; }

        public virtual GPU.GPU GPU { get; set; } = null!;
        public virtual DisplayConnector.DisplayConnector DisplayConnector { get; set; } = null!;

        public GPUDisplayConnector()
        {

        }

        public GPUDisplayConnector(Guid gpuUUID, DTO.Create gpuDisplayConnector)
        {
            GPUUUID = gpuUUID;
            DisplayConnectorUUID = gpuDisplayConnector.DisplayConnectorUUID;
            Count = gpuDisplayConnector.Count;
        }
    }
}
