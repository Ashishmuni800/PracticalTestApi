using Application.DTO;
using Application.ServiceInterface;
using Microsoft.AspNetCore.Mvc;

namespace PracticalTestApi.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class StateController : Controller
    {
        private readonly IServiceInfra _Auth;
        public StateController(IServiceInfra Auth)
        {
            _Auth = Auth;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var User = await _Auth.StateService.GetStateAsync().ConfigureAwait(false);
            return Ok(User);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Index([FromRoute] int id)
        {
            var User = await _Auth.StateService.GetStateByIdAsync(id).ConfigureAwait(false);
            return Ok(User);
        }
        [HttpGet("{CountryId}")]
        public async Task<IActionResult> GetStateByCountryId([FromRoute] int CountryId)
        {
            var User = await _Auth.StateService.GetStateByCountryIdAsync(CountryId).ConfigureAwait(false);
            return Ok(User);
        }
        [HttpPost]
        public async Task<IActionResult> AddState([FromBody] StateDTO model)
        {
            var User = await _Auth.StateService.AddStateAsync(model).ConfigureAwait(false);
            return Ok();
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> EditState(int id, [FromBody] StateDTO model)
        {
            var User = await _Auth.StateService.EditStateAsync(model).ConfigureAwait(false);
            return Ok(User);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser([FromRoute] int id)
        {
            await _Auth.StateService.DeletedAsync(id).ConfigureAwait(false);
            return Ok();
        }
    }
}
