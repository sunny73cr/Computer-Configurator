namespace ComputerConfigurator.Api.Manufacturer
{
    public partial class Manufacturer
    {
        public Guid UUID { get; set; } = Guid.Empty;
        public string Name { get; set; } = null!;

        public Manufacturer()
        {

        }

        public Manufacturer(DTO.Create manufacturer)
        {
            UUID = Guid.NewGuid();
            Name = manufacturer.Name;
        }

        public static void Edit(Manufacturer manufacturer, DTO.Edit edits)
        {
            if (manufacturer.Name != edits.Name) manufacturer.Name = edits.Name;
        }
    }
}
