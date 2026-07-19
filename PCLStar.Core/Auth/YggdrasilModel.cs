using Newtonsoft.Json;

namespace PCLStar.Core.Auth
{
    public class YggdrasilAuthResponse
    {
        [JsonProperty("accessToken")] public string AccessToken { get; set; }
        [JsonProperty("clientToken")] public string ClientToken { get; set; }
        [JsonProperty("selectedProfile")] public Profile SelectedProfile { get; set; }
        [JsonProperty("user")] public User User { get; set; }
    }

    public class Profile
    {
        [JsonProperty("id")] public string Id { get; set; }
        [JsonProperty("name")] public string Name { get; set; }
    }

    public class User
    {
        [JsonProperty("id")] public string Id { get; set; }
        [JsonProperty("username")] public string Username { get; set; }
    }
}
