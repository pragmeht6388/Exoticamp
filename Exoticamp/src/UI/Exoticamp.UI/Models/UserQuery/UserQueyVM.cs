using System.ComponentModel.DataAnnotations;

namespace Exoticamp.UI.Models.UserQuery
{
    public class UserQueyVM
    {
        public Guid Id { get; set; }
        [Required(ErrorMessage ="Please enter email")]
        [EmailAddress(ErrorMessage = "Please enter valid email")]
        public string? Email { get; set; }
        public string? Query { get; set; }
        [Required(ErrorMessage = "Please enter response before sending email")]
        public string? Response { get; set; }
        
    }
}
