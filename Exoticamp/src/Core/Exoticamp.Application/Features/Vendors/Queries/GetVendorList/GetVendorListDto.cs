﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exoticamp.Application.Features.Vendors.Queries.GetVendorList
{
    public class GetVendorListDto
    {
        public  string Id { get; set; }
        [Required]
        public string Name { get; set; }


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

        [Required]
        public string Role { get; set; }

        public bool IsLocked { get; set; }
        public int LoginAttemptCount { get; set; }
    }
}
