using Application.DTO;
using Application.ServiceInterface;
using Microsoft.AspNetCore.Mvc;

namespace PracticalTestApi.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class ProductController : Controller
    {
        private readonly IProductService _IProductService;
        public ProductController(IProductService IProductService)
        {
            _IProductService = IProductService;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var Produc = await _IProductService.GetProductAsync().ConfigureAwait(false);
            return Ok(Produc);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Index([FromRoute] int id)
        {
            var Produc = await _IProductService.GetProductByIdAsync(id).ConfigureAwait(false);
            return Ok(Produc);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            await _IProductService.DeletedAsync(id).ConfigureAwait(false);
            return Ok();
        }
        [HttpPut("{Id}")]
        public async Task<IActionResult> Edit(int Id, [FromBody] ProductDTO product)
        {
            var Produc = await _IProductService.EditProductAsync(product).ConfigureAwait(false);
            return Ok(Produc);
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ProductDTO product)
        {
            var Produc = await _IProductService.AddProductAsync(product).ConfigureAwait(false);
            return Ok(Produc);
        }
    }
}
