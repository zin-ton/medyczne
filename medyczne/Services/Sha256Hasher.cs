using System.Security.Cryptography;
using System.Text;

namespace medyczne.Services;

public class Sha256Hasher
{
    public static string HashString(string input)
    {
        byte[] bytes = Encoding.UTF8.GetBytes(input);

        using (SHA256 sha256 = SHA256.Create())
        {
            byte[] hashBytes = sha256.ComputeHash(bytes);
            StringBuilder sb = new StringBuilder();
            foreach (byte b in hashBytes)
            {
                sb.Append(b.ToString("x2"));
            }

            return sb.ToString();
        }
    }
}