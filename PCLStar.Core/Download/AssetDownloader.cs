using Newtonsoft.Json.Linq;
using PCLStar.Core.Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

namespace PCLStar.Core.Download
{
    public class AssetDownloader
    {
        private readonly string _assetsDir;
        private readonly HttpClient _http = new HttpClient();

        public AssetDownloader(string minecraftDir)
        {
            _assetsDir = Path.Combine(minecraftDir, "assets");
        }

        public async Task DownloadAssetsAsync(string versionId, JObject versionJson)
        {
            var indexId = versionJson["assetIndex"]?["id"]?.ToString() ?? versionId;
            var indexUrl = $"https://bmclapi2.byim.top/assets/{indexId}.json";
            var indexPath = Path.Combine(_assetsDir, "indexes", $"{indexId}.json");

            // 下载索引
            if (!File.Exists(indexPath))
            {
                LogHelper.Info($"下载资源索引: {indexId}");
                Directory.CreateDirectory(Path.GetDirectoryName(indexPath));
                var indexJson = await _http.GetStringAsync(indexUrl);
                await File.WriteAllTextAsync(indexPath, indexJson);
            }

            // 解析索引并下载
            var json = JObject.Parse(await File.ReadAllTextAsync(indexPath));
            var objects = json["objects"] as JObject;
            if (objects == null) return;

            var tasks = new List<Task>();
            foreach (var prop in objects.Properties())
            {
                var hash = prop.Value["hash"]?.ToString();
                if (string.IsNullOrEmpty(hash)) continue;

                var subPath = hash.Substring(0, 2);
                var destPath = Path.Combine(_assetsDir, "objects", subPath, hash);
                if (File.Exists(destPath)) continue;

                var url = $"https://bmclapi2.byim.top/assets/{subPath}/{hash}";
                tasks.Add(DownloadFileAsync(url, destPath));
            }

            await Task.WhenAll(tasks);
            LogHelper.Info("资源文件下载完成");
        }

        private async Task DownloadFileAsync(string url, string dest)
        {
            try
            {
                Directory.CreateDirectory(Path.GetDirectoryName(dest));
                var bytes = await _http.GetByteArrayAsync(url);
                await File.WriteAllBytesAsync(dest, bytes);
            }
            catch (Exception ex)
            {
                LogHelper.Error($"下载资源失败 {url}: {ex.Message}");
            }
        }
    }
}
