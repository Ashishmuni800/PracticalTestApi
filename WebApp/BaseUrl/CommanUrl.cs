
namespace WebApp.BaseUrl
{
    public class CommanUrl
    {
        private readonly IConfiguration _configuration;  
        public CommanUrl(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public string SetUrl(string Url)
        {
            string BaseUrl = _configuration["BaseUrl"];

            // Ensure BaseUrl ends with a '/' if not already
            if (!string.IsNullOrEmpty(BaseUrl) && !BaseUrl.EndsWith("/"))
            {
                BaseUrl += "/";
            }
            // Return the combined URL
            return BaseUrl + Url;
        }

    }
}
