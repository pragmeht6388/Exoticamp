
using Exoticamp.UI.Models.CampsiteDetails;
using Exoticamp.UI.Models.Events;
using Exoticamp.UI.Models.Location;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace Exoticamp.UI.Models.Booking
{
    public class BookingVM
    {
        public Guid? BookingId { get; set; }
        [Required(ErrorMessage = "Please enter name")]
        [StringLength(50, MinimumLength = 3)]
        public string CustomerName { get; set; }
        [Required(ErrorMessage = "Email is required."),]
        [EmailAddress(ErrorMessage = "Invalid email address.")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Please select the date")]
        [DataType(DataType.Date)]
        [CustomValidation(typeof(BookingVM), nameof(ValidateStartDate))]
        public DateTime CheckIn { get; set; }
        [Required(ErrorMessage = "Please select the date")]
        [DataType(DataType.Date)]
        [CustomValidation(typeof(BookingVM), nameof(ValidateEndDate))]
        public DateTime CheckOut { get; set; }
        [Required(ErrorMessage ="Enter the number of persons")]
        public int NoOfAdults { get; set; }
        [Required(ErrorMessage = "Enter the number of Childs")]
        public int NoOfChildrens { get; set; }
        [Required(ErrorMessage = "Enter the number of Tents")]
        public int NoOfTents { get; set; }

        public decimal TotalPrice { get; set; }

        public string? GlampingType { get; set; }
        public decimal? PriceForAdults { get; set; }
        public decimal? PriceForChildrens { get; set; }
        public decimal? PriceForTents { get; set; }

        public DateTime CreatedDate { get; set; }
        public string Status { get; set; }
        [Required(ErrorMessage ="Select Campsite")]
        public Guid CampsiteId { get; set; }
        [Required(ErrorMessage ="Select Location")]
        public Guid LocationId { get; set; }

        //public Guid? PaymentId { get; set; }
        public CampsiteDetailsVM? Campsite { get; set; }
        public LocationVM? Location { get; set; }


        public SelectList? LocationsList { get; set; }
        public SelectList? CampsitesList { get; set; }

    




        public static ValidationResult ValidateStartDate(DateTime checkin, ValidationContext context)
        {
            if (checkin <= DateTime.Now)
            {
                return new ValidationResult("Check in date must be greater than the current date.");
            }
            return ValidationResult.Success;
        }

        public static ValidationResult ValidateEndDate(DateTime checkout, ValidationContext context)
        {
            var instance = context.ObjectInstance as BookingVM;
            if (instance != null && checkout <= instance.CheckIn)
            {
                return new ValidationResult("Check Out date must be greater than the Check In date.");
            }
            return ValidationResult.Success;
        }
        public void CalculateTotalPrice()
        {
            decimal priceForAdults = PriceForAdults ?? 0;
            decimal priceForChildren = PriceForChildrens ?? 0;

            TotalPrice = (NoOfAdults * priceForAdults) + (NoOfChildrens * priceForChildren) + (NoOfTents * 100); // Assume $100 per tent
        }
    }

    public class BookingCampsiteList
    {
       
            public List<BookingVM> Bookings { get; set; }
            public List<CampsiteDetailsVM> Campsites { get; set; }
        public List<BookingVM> UpcomingBookings { get; set; }
        public List<BookingVM> PastBookings { get; set; }
    

    }
}
