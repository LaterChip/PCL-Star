using SharpCompress.Archives;
using SharpCompress.Common;
using System.IO;

namespace PCLStar.Core.File
{
    public static class ZipHelper
    {
        public static void ExtractZip(string zipPath, string outDir)
        {
            if (!Directory.Exists(outDir))
                Directory.CreateDirectory(outDir);

            using var archive = ArchiveFactory.Open(zipPath);
            foreach (var entry in archive.Entries)
            {
                if (!entry.IsDirectory)
                {
                    entry.WriteToDirectory(outDir, new ExtractionOptions
                    {
                        ExtractFullPath = true,
                        Overwrite = true
                    });
                }
            }
        }
    }
}
