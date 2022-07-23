namespace ComputerConfigurator.Api.Manufacturer
{
    public partial class Manufacturer
    {
        public const string SQLParameters = "uuid, name";

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

        public Manufacturer(IDictionary<string, object> manufacturer)
        {
            UUID = (Guid)manufacturer["uuid"];
            Name = (string)manufacturer["name"];
        }

        public static void Edit(Manufacturer manufacturer, DTO.Edit edits)
        {
            if (manufacturer.Name != edits.Name) manufacturer.Name = edits.Name;
        }
    }
}
