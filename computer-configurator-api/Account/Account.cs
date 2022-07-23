namespace ComputerConfigurator.Api.Account
{
    public partial class Account
    {
        public const string SQLParameters = "uuid, email, name, password, salt, timestampcreated";

        public Guid UUID { get; set; }
        public string Email { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string Salt { get; set; } = null!;
        public DateTime TimestampCreated { get; set; }

        public Account()
        {

        }

        public Account(DTO.Create account, string hashedPassword, string salt)
        {
            UUID = Guid.NewGuid();
            Email = account.Email;
            Name = account.Name;
            Password = hashedPassword;
            Salt = salt;
            TimestampCreated = DateTime.UtcNow;
        }

        public Account(IDictionary<string, object> account)
        {
            UUID = (Guid)account["uuid"];
            Email = (string)account["email"];
            Name = (string)account["name"];
            Password = (string)account["password"];
            Salt = (string)account["salt"];
            TimestampCreated = (DateTime)account["timestampcreated"];
        }

        public static void Edit(Account account, DTO.Edit edits)
        {
            if (account.Email != edits.Email) account.Email = edits.Email;

            if (account.Name != edits.Name) account.Name = edits.Name;
        }
    }
}
