namespace ComputerConfigurator.Api.MotherboardChipset.DTO
{
    public class Details
    {
        public Guid UUID { get; set; }
        public CPUSocket.DTO.Details CPUSocket { get; set; } = null!;
        public Manufacturer.DTO.Details Manufacturer { get; set; } = null!;
        public string Version { get; set; } = null!;

        public Details()
        {

        }

        public Details(MotherboardChipset MotherboardChipset)
        {
            UUID = MotherboardChipset.UUID;
            CPUSocket = new CPUSocket.DTO.Details(MotherboardChipset.CPUSocket);
            Manufacturer = new Manufacturer.DTO.Details(MotherboardChipset.Manufacturer);
            Version = MotherboardChipset.Version;
        }
    }
}
