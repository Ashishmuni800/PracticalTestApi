using Application.DTO;
using Application.ServiceInterface;
using Microsoft.AspNetCore.Mvc;

namespace PracticalTestApi.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class CountryController : Controller
    {
        private readonly IServiceInfra _Auth;
        public CountryController(IServiceInfra Auth)
        {
            _Auth = Auth;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var User = await _Auth.CountryService.GetCountryAsync().ConfigureAwait(false);
            return Ok(User);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Index([FromRoute] int id)
        {
            var User = await _Auth.CountryService.GetCountryByIdAsync(id).ConfigureAwait(false);
            return Ok(User);
        }
        [HttpPost]
        public async Task<IActionResult> AddCountry([FromBody] CountryDTO model)
        {
            var User = await _Auth.CountryService.AddCountryAsync(model).ConfigureAwait(false);
            return Ok();
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> EditCountry(int id, [FromBody] CountryDTO model)
        {
            var User = await _Auth.CountryService.EditCountryAsync(model).ConfigureAwait(false);
            return Ok(User);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser([FromRoute] int id)
        {
            await _Auth.CountryService.DeletedAsync(id).ConfigureAwait(false);
            return Ok();
        }
    }
}
