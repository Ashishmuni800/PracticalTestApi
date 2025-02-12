using Application.DTO;
using Application.ServiceInterface;
using Microsoft.AspNetCore.Mvc;

namespace PracticalTestApi.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class PrasonalDetailsController : Controller
    {
        private readonly IServiceInfra _Auth;
        public PrasonalDetailsController(IServiceInfra Auth)
        {
            _Auth = Auth;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var User = await _Auth.PrasonalDetailsService.GetPrasonalDetailsAsync().ConfigureAwait(false);
            return Ok(User);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Index([FromRoute] int id)
        {
            var User = await _Auth.PrasonalDetailsService.GetPrasonalDetailsByIdAsync(id).ConfigureAwait(false);
            return Ok(User);
        }
        [HttpPost]
        public async Task<IActionResult> AddPersonalDetails([FromBody] PrasonalDetailsDTO model)
        {
            var User = await _Auth.PrasonalDetailsService.AddPrasonalDetailsAsync(model).ConfigureAwait(false);
            return Ok();
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> EditPersonalDetails(int id, [FromBody] PrasonalDetailsDTO model)
        {
            var User = await _Auth.PrasonalDetailsService.EditPrasonalDetailsAsync(model).ConfigureAwait(false);
            return Ok(User);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePersonalDetails([FromRoute] int id)
        {
            await _Auth.PrasonalDetailsService.DeletedAsync(id).ConfigureAwait(false);
            return Ok();
        }
    }
}
