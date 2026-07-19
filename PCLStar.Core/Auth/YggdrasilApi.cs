using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace PCLStar.Core.Auth
{
    public class YggdrasilApi
    {
        private readonly HttpClient _http = new HttpClient();
        public string BaseUrl { get; set; } = "https://authserver.mojang.com";

        public async Task<YggdrasilAuthResponse> AuthenticateAsync(string username, string password)
        {
            var payload = new
            {
                agent = new { name = "Minecraft", version = 1 },
                username,
                password,
                clientToken = Guid.NewGuid().ToString()
            };
            var content = new StringContent(JsonConvert.SerializeObject(payload), Encoding.UTF8, "application/json");
            var resp = await _http.PostAsync($"{BaseUrl}/authenticate", content);
            resp.EnsureSuccessStatusCode();
            var json = await resp.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<YggdrasilAuthResponse>(json);
        }

        public async Task<bool> ValidateAsync(string accessToken)
        {
            var payload = new { accessToken };
            var content = new StringContent(JsonConvert.SerializeObject(payload), Encoding.UTF8, "application/json");
            var resp = await _http.PostAsync($"{BaseUrl}/validate", content);
            return resp.IsSuccessStatusCode;
        }

        public async Task InvalidateAsync(string accessToken, string clientToken)
        {
            var payload = new { accessToken, clientToken };
            var content = new StringContent(JsonConvert.SerializeObject(payload), Encoding.UTF8, "application/json");
            await _http.PostAsync($"{BaseUrl}/invalidate", content);
        }
    }
}
