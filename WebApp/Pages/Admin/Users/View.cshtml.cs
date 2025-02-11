using Application.ApiHttpClient;
using Application.DTO;
using Application.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Newtonsoft.Json;
using System.Text;
using WebApp.BaseUrl;

namespace WebApp.Pages.Admin.Users
{
    public class ViewModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly CommanUrl _commanUrl;
        private readonly IHttpClients _httpClient;
        public ViewModel(ILogger<IndexModel> logger,CommanUrl commanUrl, IHttpClients httpClient)
        {
            _logger = logger;
            _commanUrl = commanUrl;
            _httpClient = httpClient;
        }
        [BindProperty]
        public AspNetUsersDTO NetUsersDTOModels { get; set; } = default!;
        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }
            string baseUrl = _commanUrl.SetUrl("Auth/Index");
            var response = await _httpClient.GetByIdAsync(baseUrl, id).ConfigureAwait(false);
            if (response == null)
            {
                return NotFound();
            }
            NetUsersDTOModels = !string.IsNullOrEmpty(response) ? JsonConvert.DeserializeObject<AspNetUsersDTO>(response) : null;
            return Page();
        }
    }
}
