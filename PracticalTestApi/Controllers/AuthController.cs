using Application.DTO;
using Application.ServiceInterface;
using Domain.Model;
using Microsoft.AspNetCore.Mvc;

namespace PracticalTestApi.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class AuthController : Controller
    {
        private readonly IServiceInfra _Auth;
        public AuthController(IServiceInfra Auth)
        {
            _Auth = Auth;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var User = await _Auth.AuthService.GetUserAsync().ConfigureAwait(false);
            return Ok(User);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Index([FromRoute] string id)
        {
            var User = await _Auth.AuthService.GetUserByIdAsync(id).ConfigureAwait(false);
            return Ok(User);
        }
        [HttpPost]
        public async Task<IActionResult> Login([FromBody] AspNetUsersDTO model)
        {
            var User = await _Auth.AuthService.LoginAsync(model).ConfigureAwait(false);
            return Ok(User);
        }
        [HttpPost]
        public async Task<IActionResult> Registration([FromBody] AspNetUsersDTO model)
        {
            var User = await _Auth.AuthService.ResistrationAsync(model).ConfigureAwait(false);
            return Ok();
        } 
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(string id, [FromBody] AspNetUsersDTO model)
        {
            var User = await _Auth.AuthService.UpdateAsync(model).ConfigureAwait(false);
            return Ok(User);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser([FromRoute] string id)
        {
            await _Auth.AuthService.DeletedAsync(id).ConfigureAwait(false);
            return Ok();
        }

    }
}
