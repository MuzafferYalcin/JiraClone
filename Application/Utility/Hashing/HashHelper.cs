using System.Text;
using Microsoft.VisualBasic;

namespace Application.Utility.Hashing;

public sealed class HashHelper
{
    public static void CreateHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
    {
        using (var hmac = new System.Security.Cryptography.HMACSHA512())
        {
            passwordSalt = hmac.Key;
            passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
        }
    }

    public static bool ConfirmPassword(string password, byte[] passwordHash, byte[] passwordSalt)
    {
        using (var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt))
        {
            var confirmHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            for (int i = 0; i < confirmHash.Length; i++)
            {
                if (passwordHash[i] != confirmHash[i])
                {
                    return false;
                }
            }
            return true;
        }
    }
}