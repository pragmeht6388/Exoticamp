using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exoticamp.Application.Features.CampsiteDetails.Query.GetCampsiteDetailsList
{
    public class CampsiteDetailsVM
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public bool Status { get; set; }
        public string TentType { get; set; }

        public string Images { get; set; }
        public DateTime DateTime { get; set; }

        public string Highlights { get; set; }

        public string Ratings { get; set; }

        public string AboutCampsite { get; set; }

        public string CampsiteRules { get; set; }

        public string BestTimeToVisit { get; set; }

        public string HowToGetHere { get; set; }

        public string QuickSummary { get; set; }

        public Guid CategoryId { get; set; }
        public string CategoryName { get; set; }
        public Domain.Entities.Category  Categories { get; set; }
        public Guid ActivitiesId { get; set; }

        public string ActivitiesName { get; set; }
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
    }
}
