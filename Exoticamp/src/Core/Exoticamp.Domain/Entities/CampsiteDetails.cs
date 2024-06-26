﻿using Exoticamp.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exoticamp.Domain.Entities
{
    public class CampsiteDetails : AuditableEntity
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public bool Status { get; set; }
        //public string TentType { get; set; }
        public Guid TentId { get; set; }
        public int NoOfTents { get; set; }
        public Guid CategoryId { get; set; }
        public string Images { get; set; }
        public DateTime DateTime { get; set; }
        public decimal Price { get; set; }
        public string Highlights { get; set; }

        public string Ratings { get; set; }

        public string AboutCampsite { get; set; }

        public string CampsiteRules { get; set; }

        public string BestTimeToVisit { get; set; }

        public string HowToGetHere { get; set; }

        public string QuickSummary { get; set; }

     
      
       

        public string MealPlans { get; set; }

        public string Itinerary { get; set; }

        public string Inclusions { get; set; }
        public string Exclusion { get; set; }

        public string Amenities { get; set; }

        public string Accommodation { get; set; }

        public string Safety { get; set; }

        public string DistanceWithMap { get; set; }

        public string WhyExoticamp { get; set; }

        public string FAQs { get; set; }

        public string HouseRules { get; set; }

        public string CancellationPolicy { get; set; }
        public bool? isActive { get; set; }
        public string? ApprovedBy { get; set; }
        public DateTime? ApprovededDate { get; set; }
        public string? DeletededBy { get; set; }
        public DateTime? DeletedDate { get; set; }

        [ForeignKey("CategoryId")]
        public virtual Category Category { get; set; }
     
        public ICollection<CampsiteActivities> CampsiteActivities { get; set; }
        public virtual Tent Tent { get; set; }
    }
}
