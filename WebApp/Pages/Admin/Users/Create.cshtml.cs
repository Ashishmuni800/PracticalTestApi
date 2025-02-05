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

namespace WebApp.Pages.Admin.Users
{
    public class CreateModel : PageModel
    {
        private readonly CommanUrl _commanUrl;
        private readonly IHttpClients _httpClient;
        private readonly IWebHostEnvironment environment;
        public CreateModel(CommanUrl commanUrl, IHttpClients httpClient, IWebHostEnvironment environment)
        {
            _commanUrl = commanUrl;
            _httpClient = httpClient;
            this.environment = environment;
        }
        [BindProperty]
        public AspNetUsersDTO NetUsersDTOModels { get; set; }
        [BindProperty, Display(Name = "Profiles Image")]
        public IFormFile ProfilesImage { get; set; }
        public async Task<IActionResult> OnPostAsync()
        {
            NetUsersDTOModels.Images = ProfilesImage.FileName;
            var imageFile = Path.Combine(environment.WebRootPath, "images", "Users", ProfilesImage.FileName);
            using var fileStream = new FileStream(imageFile, FileMode.Create);
            await ProfilesImage.CopyToAsync(fileStream);

            string BaseUrl = _commanUrl.SetUrl("/Auth/Registration");
            var response = await _httpClient.PostAsync(BaseUrl, NetUsersDTOModels).ConfigureAwait(false);
            if (response != null)
            {
                return RedirectToPage("Index");
            }
            else
            {
                return BadRequest("Created Failed");
            }
            return Page();
        }


    }
}
