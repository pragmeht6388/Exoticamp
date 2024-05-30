using System.ComponentModel.DataAnnotations;

namespace Exoticamp.UI.Models.Login
{
    public class LoginVM
    {
        [Required]
        public  string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
