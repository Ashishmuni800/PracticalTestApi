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
        private readonly HttpClient _httpClient;
        public IndexModel(ILogger<IndexModel> logger,CommanUrl commanUrl, HttpClient httpClient)
        {
            _logger = logger;
            _commanUrl = commanUrl;
            _httpClient = httpClient;
        }
        public List<AspNetUsersViewModel> UsersViewModels { get; set; }

        public async Task<IActionResult> OnGet()
        {
            string BaseUrl = _commanUrl.SetUrl("/Auth/index");

            // Sending the GET request asynchronously
            var response = await _httpClient.GetAsync(BaseUrl).ConfigureAwait(false);

            // Check if the request was successful
            if (response.IsSuccessStatusCode)
            {
                // Read the response content as a string
                var responseContent = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

                // Deserialize the content to a list of AspNetUsersViewModel
                UsersViewModels = !string.IsNullOrEmpty(responseContent)
                    ? JsonConvert.DeserializeObject<List<AspNetUsersViewModel>>(responseContent)
                    : null;

                return new PartialViewResult
                {
                    ViewName = "_UserDetailsPartial",
                    ViewData = new ViewDataDictionary<List<AspNetUsersViewModel>>(ViewData, UsersViewModels)
                }; return Page();
            }

            // If the response was not successful, return the page with no users
            return Page();
        }
        public async Task<IActionResult> OnPostAsync(AspNetUsersDTO model)
        {
            string BaseUrl = _commanUrl.SetUrl("/Auth/Registration");

            // Serialize the model to JSON
            var jsonContent = JsonConvert.SerializeObject(model);

            // Create a StringContent object with the serialized JSON and set the content type to application/json
            var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

            // Sending the POST request asynchronously with the JSON content
            var response = await _httpClient.PostAsync(BaseUrl, content).ConfigureAwait(false);

            // Check if the request was successful
            if (response.IsSuccessStatusCode)
            {
                // Handle success, e.g., redirect or display a success message
                return Page();
            }
            else
            {
                // Handle failure, possibly with error message or validation feedback
                // Optionally, you can read the response content to display error details.
                var errorContent = await response.Content.ReadAsStringAsync();
                // Optionally log or handle errorContent if necessary
                return Page();
            }
        }


    }
}
