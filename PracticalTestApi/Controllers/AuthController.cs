using Application.DTO;
using Application.Service;
using Application.ServiceInterface;
using Application.TokenGenerator;
using Domain.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace PracticalTestApi.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class AuthController : Controller
    {
        private readonly IServiceInfra _Auth;
        private readonly TokenGenerator _tokenGenerator;
        private readonly IEmailService _emailService;
        public AuthController(IServiceInfra Auth, TokenGenerator tokenGenerator,IEmailService emailService)
        {
            _Auth = Auth;
            _tokenGenerator = tokenGenerator;
            _emailService = emailService;
        }
        [HttpGet]
        [Authorize]
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
        //[HttpPost]
        //public async Task<IActionResult> Login([FromBody] AspNetUsersDTO model)
        //{
        //    var User = await _Auth.AuthService.LoginAsync(model).ConfigureAwait(false);
        //    return Ok(User);
        //}

        [HttpPost]
        public async Task<IActionResult> Login([FromBody] AspNetUsersDTO request, CancellationToken cancellationToken)
        {
            // Fetch user by email
            var user = await _Auth.AuthService.GetUserByEmailAsync(request.Email);
            if (user == null //|| !BCrypt.Net.BCrypt.Verify(request.Password, user.PasswordHash)
                )
            {
                return Unauthorized("Invalid email or password");
            }

            // Generate JWT and refresh token
            var jwtToken = _tokenGenerator.GenerateAccessToken(user.Id, user.Email);
            var refreshToken = new RefreshTokenDTO(user.Id, _tokenGenerator.GenerateRefreshToken());

            // Save refresh token in database
            await _Auth.AuthService.AddRefreshTokensAsync(refreshToken);
             _Auth.AuthService.SaveChangesAsync(cancellationToken);

            // Return successful response with tokens
            var loginResponse = new LoginResponse(jwtToken, refreshToken.Token);
            return Ok(loginResponse);
        }

        [HttpPost]
        public async Task<IActionResult> Registration([FromBody] AspNetUsersDTO model)
        {
            var User = await _Auth.AuthService.ResistrationAsync(model).ConfigureAwait(false);
            if(User != null)
            {
                var subject = "Test Email";
                var body = "<h1>Hello, this is a test email!</h1>";

                await _emailService.SendEmailAsync(model.Email, subject, body);

                return Ok("Email sent successfully!");
            }
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
