using FiorelloP416app.Entities;
using Microsoft.AspNetCore.Identity;

namespace FiorelloP416app.ModelViews.AdminRole
{
    public class UpdateRoleVM
    {
        public List<IdentityRole> Roles { get; set; }
        public IList<string> UserRoles { get; set; }
        public AppUser User { get; set; }
    }
}
