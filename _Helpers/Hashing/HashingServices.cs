using System.Security.Cryptography;
using System.Text;

namespace WinDLMSClientApp._Helpers.Hashing
{
    public class HashingServices: IHashing
    {
        private const int SaltSize = 128 / 8;
        private const int KeySize = 256 / 8;
        private const int Iterations = 10000;
        private static readonly HashAlgorithmName HashAlgorithm = HashAlgorithmName.SHA512;
        private const char Separator = '/';

        public string HashValue(string value)
        {
            var salt = RandomNumberGenerator.GetBytes(SaltSize);
            var hash = Rfc2898DeriveBytes.Pbkdf2(Encoding.UTF8.GetBytes(value), salt, Iterations, HashAlgorithm, KeySize);
            return string.Concat(Convert.ToBase64String(salt), Separator, Convert.ToBase64String(hash));
        }

        public bool VerifyHash(string hash, string value)
        {
            var parts = hash.Split(Separator);
            var salt = Convert.FromBase64String(parts[0]);
            var hashv = Convert.FromBase64String(parts[1]);
            var hashv2 = Rfc2898DeriveBytes.Pbkdf2(Encoding.UTF8.GetBytes(value), salt, Iterations, HashAlgorithm, KeySize);
            return hashv.SequenceEqual(hashv2);
        }
    }
}
