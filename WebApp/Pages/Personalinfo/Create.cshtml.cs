using Application.ApiHttpClient;
using Application.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using WebApp.BaseUrl;
using WebApp.ImageUploads;

namespace WebApp.Pages.Personalinfo
{
    public class CreateModel : PageModel
    {
        private readonly CommanUrl _commanUrl;
        private readonly IHttpClients _httpClient;
        private readonly CommanImageUploades _CommanImage;
        public CreateModel(CommanUrl commanUrl,
                           IHttpClients httpClient,
                           CommanImageUploades CommanImage)
        {
            _commanUrl = commanUrl;
            _httpClient = httpClient;
            this._CommanImage = CommanImage;
        }
        [BindProperty]
        public PrasonalDetailsDTO PrasonalDetailsDTOModels { get; set; }
        public async Task<IActionResult> OnPostAsync()
        {
            string BaseUrl = _commanUrl.SetUrl("PrasonalDetails/AddPersonalDetails");
            var response = await _httpClient.PostAsync(BaseUrl, PrasonalDetailsDTOModels).ConfigureAwait(false);
            if (response != null)
            {
                return RedirectToPage("Index");
            }
            else
            {
                return BadRequest("Created Failed");
            }
        }
    }
}
