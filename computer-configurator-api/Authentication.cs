using Konscious.Security.Cryptography;
using System.Security.Cryptography;

namespace ComputerConfigurator.Api
{
    public static class Authentication
    {
        public static byte[] Hash(byte[] password, byte[] salt)
        {
            using var argon2id = new Argon2id(password);

            argon2id.DegreeOfParallelism = 12;
            argon2id.MemorySize = 160000;
            argon2id.Iterations = 2;
            argon2id.Salt = salt;

            return argon2id.GetBytes(16);
        }

        public static byte[] CreateSalt()
        {
            byte[] saltBuffer = new byte[16];

            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(saltBuffer);
            }

            return saltBuffer;
        }
    }
}
