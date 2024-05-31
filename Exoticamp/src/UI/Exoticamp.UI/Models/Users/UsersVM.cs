using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using Newtonsoft.Json;

namespace Exoticamp.UI.Models.Users
{
    public class UsersVM
    {
      
        public string Name { get; set; }


        [Required]

        public string PhoneNumber { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

 

         

        [Required]
        public string Role { get; set; }
    }
}
