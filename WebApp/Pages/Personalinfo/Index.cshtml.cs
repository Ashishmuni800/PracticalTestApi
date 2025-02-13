using Application.ApiHttpClient;
using Application.DTO;
using Application.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Newtonsoft.Json;
using WebApp.BaseUrl;

namespace WebApp.Pages.Personalinfo
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly CommanUrl _commanUrl;
        private readonly IHttpClients _httpClient;
        public IndexModel(ILogger<IndexModel> logger, CommanUrl commanUrl, IHttpClients httpClient)
        {
            _logger = logger;
            _commanUrl = commanUrl;
            _httpClient = httpClient;
        }
        public List<PrasonalDetailsViewModel> PersonalViewModels { get; set; }
        public async Task<IActionResult> OnGet()
        {
            string BaseUrl = _commanUrl.SetUrl("PrasonalDetails/index");
            var response = await _httpClient.GetAsync(BaseUrl).ConfigureAwait(false);
            if (response != null)
            {
                PersonalViewModels = !string.IsNullOrEmpty(response)
                    ? JsonConvert.DeserializeObject<List<PrasonalDetailsViewModel>>(response)
                    : null;

                return Page();
            }
            else
            {
                return BadRequest("Data not found");
            }
        }
    }
}
