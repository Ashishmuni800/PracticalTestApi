using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Application.TokenGenerator
{
    public class TokenGenerator
    {
        private readonly string _jwtSecretKey;
        private readonly string _refreshSecretKey;

        public TokenGenerator(IConfiguration configuration)
        {
            _jwtSecretKey = configuration["JwtSettings:SecretKey"];
            _refreshSecretKey = configuration["JwtSettings:RefreshSecretKey"];
        }

        public string GenerateAccessToken(string userId, string email)
        {
            var claims = new[]
            {
            new Claim(ClaimTypes.NameIdentifier, userId.ToString()),
            new Claim(ClaimTypes.Email, email)
        };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSecretKey));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expiration = DateTime.Now.AddMinutes(30); // Access token expiration time

            var token = new JwtSecurityToken(
                issuer: "https://localhost:44321/",
                audience: "https://localhost:44322/",
                claims: claims,
                expires: expiration,
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public string GenerateRefreshToken()
        {
            var randomBytes = new byte[32];
            using (var rng = new RNGCryptoServiceProvider())
            {
                rng.GetBytes(randomBytes);
            }

            return Convert.ToBase64String(randomBytes);
        }
    }
}
