﻿using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Exoticamp.Application.Models.Authentication
{
    public class RegistrationRequest
    {
       
        public string? Id { get; set; }

        [Required]
        public string  Name { get; set; }


        [Required]
         
        public string PhoneNumber { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DefaultValue(false)]
        public bool? TermsandCondition { get; set; }

        [Required]
        public string Password { get; set; }
        
        public Guid LocationId { get; set; }
        public string? Role { get; set; }



        

    }
}
