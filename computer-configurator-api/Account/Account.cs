using System.Text;

namespace ComputerConfigurator.Api.Account
{
    public partial class Account
    {
        public Guid UUID { get; set; }
        public string Email { get; set; } = string.Empty;
        public string Name { get; set; } =  string.Empty;
        public string Password { get; set; } = string.Empty;
        public string Salt { get; set; } = string.Empty;
        public DateTime TimestampCreated { get; set; }

        public Account()
        {

        }

        public Account(DTO.Create account)
        {
            UUID = account.UUID;
            Email = account.Email.ToLower();
            Name = account.Name;
            SetNewPassword(account.Password);
            TimestampCreated = account.TimestampCreated;
        }

        public static void Edit(Account account, DTO.Edit edits)
        {
            if (account.Email != edits.Email.ToLower()) account.Email = edits.Email.ToLower();
            if (account.Name != edits.Name) account.Name = edits.Name;
        }

        public bool VerifyPassword(string testPassword)
        {
            byte[] knownPasswordHash = Convert.FromBase64String(Password);

            byte[] testPasswordBytes = Encoding.Unicode.GetBytes(testPassword);

            byte[] saltBytes = Convert.FromBase64String(Salt);

            byte[] testPasswordHash = Authentication.Hash(testPasswordBytes, saltBytes);

            return knownPasswordHash.SequenceEqual(testPasswordHash);
        }

        public void SetNewPassword(string newPassword)
        {
            byte[] newSaltBytes = Authentication.CreateSalt();

            byte[] newPasswordBytes = Encoding.Unicode.GetBytes(newPassword);

            byte[] newHash = Authentication.Hash(newPasswordBytes, newSaltBytes);

            string newPasswordHashBase64 = Convert.ToBase64String(newHash);

            string newSaltBase64 = Convert.ToBase64String(newSaltBytes);

            Password = newPasswordHashBase64;

            Salt = newSaltBase64;
        }
    }
}
