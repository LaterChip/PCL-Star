using System.IO;
using Newtonsoft.Json;

namespace PCLStar.Core.Config
{
    public class GlobalConfig
    {
        public string MinecraftDir { get; set; } = @".\.minecraft";
        public string JavaPath { get; set; } = "";
        public int MaxMemory { get; set; } = 2048;
        public string SelectedTheme { get; set; } = "Dark";

        private static string ConfigPath => Path.Combine(GlobalConst.DataDir, "global.json");

        public void Save() => File.WriteAllText(ConfigPath, JsonConvert.SerializeObject(this, Formatting.Indented));

        public static GlobalConfig Load()
        {
            if (!File.Exists(ConfigPath)) return new GlobalConfig();
            return JsonConvert.DeserializeObject<GlobalConfig>(File.ReadAllText(ConfigPath));
        }
    }
}
