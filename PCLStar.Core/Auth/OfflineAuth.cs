using System.Threading.Tasks;

namespace PCLStar.Core.Auth
{
    public class OfflineAuth
    {
        public async Task<YggdrasilAuthResponse> LoginAsync(string username)
        {
            await Task.CompletedTask;
            return new YggdrasilAuthResponse
            {
                AccessToken = "offline",
                ClientToken = "offline",
                SelectedProfile = new Profile { Id = "offline", Name = username },
                User = new User { Id = "offline", Username = username }
            };
        }
    }
}
