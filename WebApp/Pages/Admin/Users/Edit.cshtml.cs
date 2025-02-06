using Application.ApiHttpClient;
using Application.DTO;
using Application.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Rewrite;
using Newtonsoft.Json;
using System;
using System.Collections.Immutable;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using WebApp.BaseUrl;

namespace WebApp.Pages.Admin.Users
{
    public class EditModel : PageModel
    {
        private readonly ILogger<DeleteModel> _logger;  // Changed to DeleteModel, since it refers to this class
        private readonly CommanUrl _commanUrl;
        private readonly IHttpClients _httpClient;
        private readonly IWebHostEnvironment environment;
        public EditModel(ILogger<DeleteModel> logger, CommanUrl commanUrl, IHttpClients httpClient, IWebHostEnvironment environment)
        {
            _logger = logger;
            _commanUrl = commanUrl;
            _httpClient = httpClient;
            this.environment = environment;
        }
        [BindProperty]
        public AspNetUsersDTO NetUsersDTOModels { get; set; } = default!;
        [BindProperty, Display(Name = "Profiles Image")]
        public IFormFile ProfilesImage { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }
            string baseUrl = _commanUrl.SetUrl("/Auth/Index");
            var response = await _httpClient.GetByIdAsync(baseUrl, id).ConfigureAwait(false);
            if (response == null)
            {
                return NotFound();
            }
            NetUsersDTOModels = !string.IsNullOrEmpty(response) ? JsonConvert.DeserializeObject<AspNetUsersDTO>(response) : null;
            return Page();
        }
        public async Task<IActionResult> OnPostAsync(string id)
        {
            NetUsersDTOModels.Images = ProfilesImage.FileName;
            var imageFile = Path.Combine(environment.WebRootPath, "images", "Users", ProfilesImage.FileName);
            using var fileStream = new FileStream(imageFile, FileMode.Create);
            await ProfilesImage.CopyToAsync(fileStream);
            string baseUrl = _commanUrl.SetUrl("/Auth/UpdateUser");
            var response = await _httpClient.PostUpdateAsync(baseUrl, id, NetUsersDTOModels).ConfigureAwait(false);

            if (response != null)
            {
                return RedirectToPage("/Admin/Users/Index");  // Redirect after successful deletion
            }
            else
            {
                // Return an error message if the deletion failed
                ModelState.AddModelError(string.Empty, "Update failed");
                return Page();
            }
        }

       
    }
}
