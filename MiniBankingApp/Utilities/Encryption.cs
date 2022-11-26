using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniBankingApp.Utilities
{
    public class Encryption
    {
        public static bool EncryptPassword(string password, out byte[] passwordSalt, out byte[] passwordHash)
        {
            // convert password to hash value and generate salt
            using (var hash = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hash.Key;
                passwordHash = hash.ComputeHash(Encoding.UTF8.GetBytes(password));
            }

            return true;
        }

        public static bool ComparePassword(byte[] passwordHash, byte[] passwordSalt, string password)
        {
            using var hash = new System.Security.Cryptography.HMACSHA512(passwordSalt);
            var hashGenerated = hash.ComputeHash(Encoding.UTF8.GetBytes(password));
            for (int i = 0; i < hashGenerated.Length; i++)
            {
                if (hashGenerated[i] != passwordHash[i])
                {
                    return false;
                }
            }
            return true;
        }
    }
}
