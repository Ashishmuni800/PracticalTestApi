﻿using Application.ApiHttpClient;
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
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly CommanUrl _commanUrl;
        private readonly IHttpClients _httpClient;
        public IndexModel(ILogger<IndexModel> logger,CommanUrl commanUrl, IHttpClients httpClient)
        {
            _logger = logger;
            _commanUrl = commanUrl;
            _httpClient = httpClient;
        }
        public List<AspNetUsersViewModel> UsersViewModels { get; set; }

        public async Task<IActionResult> OnGet()
        {
            string BaseUrl = _commanUrl.SetUrl("/Auth/index");
            var response = await _httpClient.GetAsync(BaseUrl).ConfigureAwait(false);
            if(response != null)
            {
                // Deserialize the content to a list of AspNetUsersViewModel
                UsersViewModels = !string.IsNullOrEmpty(response)
                    ? JsonConvert.DeserializeObject<List<AspNetUsersViewModel>>(response)
                    : null;

                return new PartialViewResult
                {
                    ViewName = "_UserDetailsPartial",
                    ViewData = new ViewDataDictionary<List<AspNetUsersViewModel>>(ViewData, UsersViewModels)
                }; return Page();
            }
            else
            {
                return BadRequest("Data not found");
            }
            // If the response was not successful, return the page with no users
            return Page();
        }

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
