using Application.ApiHttpClient;
using Application.DTO;
using Application.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using System.Threading.Tasks;
using WebApp.BaseUrl;

namespace WebApp.Pages.Admin.Users
{
    public class DeleteModel : PageModel
    {
        private readonly ILogger<DeleteModel> _logger;  // Changed to DeleteModel, since it refers to this class
        private readonly CommanUrl _commanUrl;
        private readonly IHttpClients _httpClient;

        public DeleteModel(ILogger<DeleteModel> logger, CommanUrl commanUrl, IHttpClients httpClient)
        {
            _logger = logger;
            _commanUrl = commanUrl;
            _httpClient = httpClient;
        }
        public async Task<IActionResult> OnPostAsync(string id)
        {
            if (id == null)  // Use null conditional check for better null safety
            {
                return NotFound();
            }

            string baseUrl = _commanUrl.SetUrl("/Auth/DeleteUser");
            var response = await _httpClient.DeleteAsync(baseUrl, id).ConfigureAwait(false);

            if (response != null)
            {
                return RedirectToPage("/Admin/Users/Index");  // Redirect after successful deletion
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
