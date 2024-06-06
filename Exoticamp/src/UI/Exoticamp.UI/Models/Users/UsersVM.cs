using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using Newtonsoft.Json;

namespace Exoticamp.UI.Models.Users
{
    public class UsersVM
    {
        public string Id { get; set; }
        public string Name { get; set; }


        [Required]

        public string PhoneNumber { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

 

         

        [Required]
        public string Role { get; set; }
        public bool IsLocked { get; set; }
        public int LoginAttemptCount { get; set; }
        public string LocationId {  get; set; }
        public string Location { get; set; }

        public string PreferenceId { get; set; }
        public string Preference { get; set; }

    }
}
