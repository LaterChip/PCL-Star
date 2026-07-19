using System.Threading.Tasks;

namespace PCLStar.Core.Auth
{
    public class LittleSkinAuth : YggdrasilApi
    {
        public LittleSkinAuth()
        {
            BaseUrl = "https://littleskin.cn/api/yggdrasil";
        }
        
        public async Task<YggdrasilAuthResponse> LoginWithLittleSkinAsync(string email, string password)
        {
            return await AuthenticateAsync(email, password);
        }
    }
}
