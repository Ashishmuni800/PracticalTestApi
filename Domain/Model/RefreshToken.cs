using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model
{
    public class RefreshToken
    {
        public string? Id { get; set; }
        public string Token { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime ExpiresAt { get; set; }

        public RefreshToken(string? Id, string token)
        {
            this.Id = Id;
            Token = token;
            CreatedAt = DateTime.UtcNow;
            ExpiresAt = DateTime.UtcNow.AddDays(7); // You can adjust the expiration time as needed
        }
    }
}
