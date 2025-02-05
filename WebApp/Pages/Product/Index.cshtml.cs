using Application.ApiHttpClient;
using Application.DTO;
using Application.ViewModel;
using Domain.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.Text;
using WebApp.BaseUrl;

namespace WebApp.Pages.Product
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly CommanUrl _commanUrl;
        private readonly IHttpClients _httpClient;
        private readonly IWebHostEnvironment environment;
        public IndexModel(ILogger<IndexModel> logger,CommanUrl commanUrl, IHttpClients httpClient, IWebHostEnvironment environment)
        {
            _logger = logger;
            _commanUrl = commanUrl;
            _httpClient = httpClient;
            this.environment = environment;
        }
        [BindProperty]
        public ProductDTO Product { get; set; } = default!;
        [BindProperty, Display(Name = "Product Image")]
        public IFormFile ProductImage { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            ModelState.Remove("Product.ImageName");
            if (!ModelState.IsValid)
            {
                return Page();
            }

            Product.ProductFile = ProductImage.FileName;
            var imageFile = Path.Combine(environment.WebRootPath, "images", "products", ProductImage.FileName);
            using var fileStream = new FileStream(imageFile, FileMode.Create);
            await ProductImage.CopyToAsync(fileStream);

            string BaseUrl = _commanUrl.SetUrl("/Product/Create");
            var response = await _httpClient.PostAsync(BaseUrl, Product).ConfigureAwait(false);

            if (response != null)
            {
                return RedirectToPage("/Admin/Users/Index"); // Redirect back to the users list
            }
            else
            {
                // Return an error message if the deletion failed
                ModelState.AddModelError(string.Empty, "Add failed");
                return Page();
            }
        }

    }
}
