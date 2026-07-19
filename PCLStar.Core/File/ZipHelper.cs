using SharpCompress.Archives;
using SharpCompress.Common;

namespace PCLStar.Core.File
{
    public static class ZipHelper
    {
        public static void ExtractZip(string zipPath, string outDir)
        {
            using var archive = ArchiveFactory.Open(zipPath);
            foreach (var entry in archive.Entries)
            {
                if (!entry.IsDirectory)
                    entry.WriteToDirectory(outDir, new ExtractionOptions { ExtractFullPath = true, Overwrite = true });
            }
        }
    }
}
