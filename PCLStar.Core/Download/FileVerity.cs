using System.IO;
using System.Security.Cryptography;

namespace PCLStar.Core.Download
{
    public static class FileVerify
    {
        public static bool VerifySha1(string filePath, string expectedSha1)
        {
            if (!File.Exists(filePath)) return false;
            using var sha1 = SHA1.Create();
            using var stream = File.OpenRead(filePath);
            var hash = sha1.ComputeHash(stream);
            var actual = BitConverter.ToString(hash).Replace("-", "").ToLower();
            return actual == expectedSha1.ToLower();
        }
    }
}
