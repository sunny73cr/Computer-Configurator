namespace ComputerConfigurator.Api.Account.DTO
{
    public class Details
    {
        public const string SQLParameters = "uuid, email, name";

        public Guid UUID { get; } = Guid.Empty;
        public string Email { get; } = string.Empty;
        public string Name { get; } = string.Empty;

        public Details()
        {

        }

        public Details(Account account)
        {
            UUID = account.UUID;
            Email = account.Email;
            Name = account.Name;
        }

        public Details(IDictionary<string, object> account)
        {
            UUID = (Guid)account["uuid"];
            Email = (string)account["email"];
            Name = (string)account["name"];
        }
    }
}
