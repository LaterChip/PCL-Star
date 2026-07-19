using System.IO;

namespace PCLStar.Core
{
    public static class GlobalConst
    {
        public static string DataDir = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "PCLStar");
    }
}
