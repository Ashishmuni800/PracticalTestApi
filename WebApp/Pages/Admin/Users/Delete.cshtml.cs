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
    public class DeleteModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly CommanUrl _commanUrl;
        private readonly IHttpClients _httpClient;
        public DeleteModel(ILogger<IndexModel> logger,CommanUrl commanUrl, IHttpClients httpClient)
        {
            _logger = logger;
            _commanUrl = commanUrl;
            _httpClient = httpClient;
        }
        public List<AspNetUsersViewModel> UsersViewModels { get; set; }

        
        [HttpPost]
        public async Task<IActionResult> Delete(string id)
        {
            string BaseUrl = _commanUrl.SetUrl("/Auth/DeleteUser");
            var response = await _httpClient.DeleteAsync(BaseUrl,id).ConfigureAwait(false);

            if (response != null)
            {
                return RedirectToPage("/Admin/Users/Index"); // Redirect back to the users list
            }
            else
            {
                // Return an error message if the deletion failed
                ModelState.AddModelError(string.Empty, "Delete failed");
                return Page();
            }
        }

    }
}
