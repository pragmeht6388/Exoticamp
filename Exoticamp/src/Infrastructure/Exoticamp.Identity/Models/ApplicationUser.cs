using Exoticamp.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Exoticamp.Identity.Models
{
    public class ApplicationUser : IdentityUser
    {

        public string Name { get; set; }
        

        [DefaultValue(false)]
        public bool? TermsandCondition { get; set; }
       
        public List<RefreshToken> RefreshTokens { get; set; }
        public Guid LocationId { get; set; }
        public Guid ActivityId { get; set; }
        public bool IsDeleted { get; set; }=false;
        public bool IsLocked { get; set; } = false;
        public int LoginAttemptCount { get; set; }

    }
}
