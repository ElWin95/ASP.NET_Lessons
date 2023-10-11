using System.ComponentModel.DataAnnotations;

namespace FiorelloP416app.ModelViews.Account
{
    public class LoginVM
    {
        [Required, StringLength(100)]
        public string UserNameOrEmail { get; set; }
        [Required, DataType(DataType.Password)]
        public string Password { get; set; }
        public bool Rememberme { get; set; }
    }
}
