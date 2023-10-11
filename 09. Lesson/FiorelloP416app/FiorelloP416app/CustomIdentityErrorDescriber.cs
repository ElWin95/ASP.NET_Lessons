using Microsoft.AspNetCore.Identity;

namespace FiorelloP416app
{
    public class CustomIdentityErrorDescriber: IdentityErrorDescriber
    {
        public override IdentityError PasswordRequiresUpper() {
            return new IdentityError {
            Code = nameof(PasswordRequiresUpper),
            Description = "Boyuk herf olmalidir.. ('A'-'Z')." }; }
    }
}
