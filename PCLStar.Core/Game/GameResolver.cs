using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace PCLStar.Core.Game
{
    public class GameResolver
    {
        public async Task<JObject> ResolveVersionAsync(string versionId, string minecraftDir)
        {
            var jsonPath = Path.Combine(minecraftDir, "versions", versionId, $"{versionId}.json");
            if (File.Exists(jsonPath))
                return JObject.Parse(await File.ReadAllTextAsync(jsonPath));

            // 从远端获取
            var url = $"https://bmclapi2.byim.top/launcher/v1/version/{versionId}.json";
            using var http = new HttpClient();
            var json = await http.GetStringAsync(url);
            Directory.CreateDirectory(Path.GetDirectoryName(jsonPath));
            await File.WriteAllTextAsync(jsonPath, json);
            return JObject.Parse(json);
        }
    }
}
