using System.IO;
using System.Text.Json;
using System.Threading.Tasks;

namespace PCLStar.Core.Auth
{
    public class AuthStorage
    {
        private readonly string _path = Path.Combine(GlobalConst.DataDir, "auth.json");

        public async Task SaveAsync(YggdrasilAuthResponse auth)
        {
            var json = JsonSerializer.Serialize(auth);
            await File.WriteAllTextAsync(_path, json);
        }

        public async Task<YggdrasilAuthResponse> LoadAsync()
        {
            if (!File.Exists(_path)) return null;
            var json = await File.ReadAllTextAsync(_path);
            return JsonSerializer.Deserialize<YggdrasilAuthResponse>(json);
        }

        public void Delete() => File.Delete(_path);
    }
}
