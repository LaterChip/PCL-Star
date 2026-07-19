namespace PCLStar.Core.Auth
{
    public class ExternalAuth : YggdrasilApi
    {
        public ExternalAuth(string customUrl)
        {
            BaseUrl = customUrl.TrimEnd('/');
        }
    }
}
