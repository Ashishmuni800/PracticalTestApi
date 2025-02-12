using Application.DTO;
using Application.ServiceInterface;
using Microsoft.AspNetCore.Mvc;

namespace PracticalTestApi.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class CityController : Controller
    {
        private readonly IServiceInfra _Auth;
        public CityController(IServiceInfra Auth)
        {
            _Auth = Auth;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var User = await _Auth.CityService.GetCityAsync().ConfigureAwait(false);
            return Ok(User);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Index([FromRoute] int id)
        {
            var User = await _Auth.CityService.GetCityByIdAsync(id).ConfigureAwait(false);
            return Ok(User);
        }
        [HttpGet("{StateId}")]
        public async Task<IActionResult> GetCityByStateId([FromRoute] int StateId)
        {
            var User = await _Auth.CityService.GetCityByStateIdAsync(StateId).ConfigureAwait(false);
            return Ok(User);
        }
        [HttpPost]
        public async Task<IActionResult> AddCity([FromBody] CityDTO model)
        {
            var User = await _Auth.CityService.AddCityAsync(model).ConfigureAwait(false);
            return Ok();
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> EditCity(int id, [FromBody] CityDTO model)
        {
            var User = await _Auth.CityService.EditCityAsync(model).ConfigureAwait(false);
            return Ok(User);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser([FromRoute] int id)
        {
            await _Auth.CityService.DeletedAsync(id).ConfigureAwait(false);
            return Ok();
        }
    }
}
