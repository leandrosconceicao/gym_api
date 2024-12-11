using System.Text;
using System.Security.Cryptography;

namespace Gym.Domain.Utils
{
    public class Crypto
    {
        public static string GetHashedPassword(string password)
        {
            return Convert.ToBase64String(SHA256.HashData(Encoding.UTF8.GetBytes(password)));
        }
    }
}
