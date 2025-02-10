using Application.ApiHttpClient;
using Application.DTO;
using Application.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;
using System.Reflection;
using System.Text;
using WebApp.BaseUrl;
using WebApp.ImageUploads;

namespace WebApp.Pages.Admin.Users
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
        public AspNetUsersDTO NetUsersDTOModels { get; set; }
        [BindProperty, Display(Name = "Profiles Image")]
        public IFormFile ProfilesImage { get; set; }
        public async Task<IActionResult> OnPostAsync()
        {
            NetUsersDTOModels.Images = ProfilesImage.FileName;
            _CommanImage.UploadImage("images","Users", ProfilesImage);
            string BaseUrl = _commanUrl.SetUrl("Auth/Registration");
            var response = await _httpClient.PostAsync(BaseUrl, NetUsersDTOModels).ConfigureAwait(false);
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
