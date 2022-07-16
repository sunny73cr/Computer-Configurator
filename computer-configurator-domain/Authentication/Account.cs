namespace ComputerConfigurator.Domain.Authentication.Account
{
    public class Account
    {
        public int Id { get; }
        public string Name { get; } = string.Empty;
        public string Password { get; } = string.Empty;
        public Session.Session? Session { get; } = null;
    }
}
