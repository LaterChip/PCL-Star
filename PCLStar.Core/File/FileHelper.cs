using System.IO;

namespace PCLStar.Core.File
{
    public static class FileHelper
    {
        public static void EnsureDirectory(string path) => Directory.CreateDirectory(path);
        public static string CombinePath(params string[] parts) => Path.Combine(parts);
        public static long GetSize(string path) => File.Exists(path) ? new FileInfo(path).Length : 0;
    }
}
