﻿using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace Exoticamp.UI.Models.Vendors
{
    public class VendorVM
    {
        public string Id { get; set; }

        [Required(ErrorMessage = "Vendor name is required.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid email address format.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Phone number is required.")]
        public string PhoneNumber { get; set; }

        public string Address { get; set; }

        [Required(ErrorMessage = "Business type is required.")]

        public string? AltPhoneNumber { get; set; }

        [EmailAddress(ErrorMessage = "Invalid email address format.")]
        public string? AltEmail { get; set; }

        public string? AltAddress { get; set; }
        //public string LocationId { get; set; }
        //public string Location { get; set; }
        public Guid LocationId { get; set; }
        [JsonProperty("LocationName")]
        public string LocationName { get; set; }
        public string IDCard { get; set; }
        public string License { get; set; }
        public string KYCAddress { get; set; }
        public string Others { get; set; }
        //public string LocationId { get; set; }
        public string BankName { get; set; }
        public string AccountNumber { get; set; }
        public string IFSCCode { get; set; }
        public string Location { get; set; }

        public bool IsLocked { get; set; }
        public int LoginAttemptCount { get; set; }
    }
}
