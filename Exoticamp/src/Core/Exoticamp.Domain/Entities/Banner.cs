﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exoticamp.Domain.Entities
{
    public class Banner
    {
        [Key]
        public Guid BannerId { get; set; }

        [Required]
        [StringLength(2048)]
        public string Link { get; set; }

        [Required]
        public bool IsActive { get; set; } = true; // Default to active

        [StringLength(50)]
        public string PromoCode { get; set; }

        //[Required]
        //public string Locations { get; set; }

        [Required]
        public string ImagePath { get; set; }

        [Required]
        public bool IsDeleted { get; set; } = false;

        public Guid LocationId { get; set; }

        [ForeignKey("LocationId")]
        public Location Location { get; set; }
    }
}
