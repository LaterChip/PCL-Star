using System;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;

namespace PCLStar.Core.Config
{
    public static class ConfigStorage
    {
        private static readonly string _configDir = Path.Combine(GlobalConst.DataDir, "configs");

        static ConfigStorage()
        {
            if (!Directory.Exists(_configDir))
                Directory.CreateDirectory(_configDir);
        }

        private static string GetPath(string fileName) => Path.Combine(_configDir, fileName);

        public static async Task SaveAsync<T>(string fileName, T data)
        {
            var json = JsonSerializer.Serialize(data, new JsonSerializerOptions { WriteIndented = true });
            await File.WriteAllTextAsync(GetPath(fileName), json);
        }

        public static async Task<T> LoadAsync<T>(string fileName) where T : new()
        {
            var path = GetPath(fileName);
            if (!File.Exists(path)) return new T();
            var json = await File.ReadAllTextAsync(path);
            return JsonSerializer.Deserialize<T>(json) ?? new T();
        }
    }
}
