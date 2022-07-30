namespace ComputerConfigurator.Api.Account.DTO
{
    public class Details
    {
        public Guid UUID { get; }
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
    }
}
