using Microsoft.AspNetCore.Identity;

namespace FiorelloP416app.Entities
{
    public class AppUser: IdentityUser
    {
        public string FullName { get; set; }
        public string? ConnectionId { get; set; }
    }
}
