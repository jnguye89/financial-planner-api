using System;
using System.Security.Cryptography;
using System.Text;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;

namespace FinancialPlanner.Services
{
    public class HashService
    {
        public static string Create(string password, string salt, int iterations = 1000)
        {
            var valueBytes = KeyDerivation.Pbkdf2(
                password: password,
                salt: Encoding.UTF8.GetBytes(salt),
                prf: KeyDerivationPrf.HMACSHA512,
                iterationCount: iterations,
                numBytesRequested: 256 / 8);

            return $"{salt}.{Convert.ToBase64String(valueBytes)}.{iterations}";
        }

        public static bool Validate(string password, string salt, int interations, string hash)
            => Create(password, salt, interations) == hash;
    }

    public class Salt
    {
        public static string Create()
        {
            byte[] randomBytes = new byte[128 / 8];
            using (var generator = RandomNumberGenerator.Create())
            {
                generator.GetBytes(randomBytes);
                return Convert.ToBase64String(randomBytes);
            }
        }
    }
}
