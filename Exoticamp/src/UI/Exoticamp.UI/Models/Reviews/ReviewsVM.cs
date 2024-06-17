﻿using System;
using System.ComponentModel.DataAnnotations;
using Exoticamp.Domain.Entities; // Assuming Booking class is defined here
using Newtonsoft.Json;

namespace Exoticamp.UI.Models.Reviews
{
    public class ReviewsVM
    {
        [Key]
        [JsonProperty("id")]
        public Guid Id { get; set; }

       
        [JsonProperty("name")]
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }

        [Display(Name = "Date and Time")] // Optional display name for UI
        [JsonProperty("dateTime")]

        public DateTime DateTime { get; set; } = DateTime.Now;

        
        [JsonProperty("ratings")]
        [Required(ErrorMessage = "Ratings is required")]
        [Range(0, 5, ErrorMessage = "Ratings must be between 0 and 5")]
        public int Ratings { get; set; }

        [JsonProperty("description")]
        [Required(ErrorMessage = "Description is required")]

        public string Description { get; set; }

        [JsonProperty("status")]
        public bool Status { get; set; } = true;

        [JsonProperty("bookingId")]
        [Required(ErrorMessage = "BookingId is required")]

        public Guid BookingId { get; set; }

        [JsonProperty("userId")]
        public Guid UserId { get; set; }

        [JsonProperty("campsite")]
        public virtual Booking Booking { get; set; }
    }
}