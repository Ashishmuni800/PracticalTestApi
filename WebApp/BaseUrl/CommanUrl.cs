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
            return BaseUrl + Url;
        }
    }
}
