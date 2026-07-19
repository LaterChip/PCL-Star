using Newtonsoft.Json.Linq;
using PCLStar.Core.Common;
using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

namespace PCLStar.Core.Download
{
    public class LibraryDownloader
    {
        private readonly string _librariesDir;
        private readonly HttpClient _http = new HttpClient();

        public LibraryDownloader(string minecraftDir)
        {
            _librariesDir = Path.Combine(minecraftDir, "libraries");
        }

        public async Task DownloadLibrariesAsync(JObject versionJson)
        {
            var libraries = versionJson["libraries"] as JArray;
            if (libraries == null) return;

            foreach (var lib in libraries)
            {
                var downloads = lib["downloads"]?["artifact"] as JObject;
                if (downloads == null) continue;

                var url = downloads["url"]?.ToString();
                var path = downloads["path"]?.ToString();
                if (string.IsNullOrEmpty(url) || string.IsNullOrEmpty(path)) continue;

                var dest = Path.Combine(_librariesDir, path.Replace('/', Path.DirectorySeparatorChar));
                if (File.Exists(dest)) continue;

                LogHelper.Info($"下载库文件: {path}");
                try
                {
                    Directory.CreateDirectory(Path.GetDirectoryName(dest));
                    var bytes = await _http.GetByteArrayAsync(url);
                    await File.WriteAllBytesAsync(dest, bytes);
                }
                catch (Exception ex)
                {
                    LogHelper.Error($"库下载失败 {path}: {ex.Message}");
                }
            }
        }
    }
}
