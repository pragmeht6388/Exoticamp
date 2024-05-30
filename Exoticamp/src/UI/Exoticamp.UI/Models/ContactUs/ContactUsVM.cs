using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Exoticamp.UI.Models.ContactUs
{
    public class ContactUsVM
    {
        [JsonProperty("id")]
        public Guid Id { get; set; }

        [JsonProperty("name")]
        [Required(ErrorMessage = "Name is Required")]
        [StringLength(100)]
        public string Name { get; set; }

        [JsonProperty("Email")]
        [Required(ErrorMessage = "Email is Required")]
        [EmailAddress]
        [StringLength(100)]
        public string Email { get; set; }

        [JsonProperty("message")]
        [Required(ErrorMessage = "Message is Required")]
        [StringLength(1000)]
        public string Message { get; set; }

        [JsonProperty("SubmittedAt")]
        public DateTime SubmittedAt { get; set; } = DateTime.Now;
    }
}
