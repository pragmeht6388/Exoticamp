﻿using Exoticamp.Domain.Entities;

namespace Exoticamp.UI.Helper
{
    public static class URLHelper
    {
        #region - Events


        public const string GetAllEvents = "/api/v1/Events";
        public const string Registration = "/api/v1/Account/register";
        public const string Login = "/api/v1/Account/authenticate";
        public const string GetAllUsers = "/api/v1/Admin/GetAllUsers";

        public const string AddEvent = "/api/v1/Events";
        public const string EditEvent = "/api/v1/Events";
        public const string GetEventById = "/api/v1/Events/{0}";
        public const string DeleteEvent = "/api/v1/Events/{0}";

        #endregion
        public const string GetAllBanners = "/api/v1/Banner/all";

        public const string AddBanners = "/api/v1/Banner";

        public const string UpdateBanners = "/api/v1/Banner/UpdateBanner";

        public const string GetbyId = "/api/v1/Banner/{0}";
        #region Admin
        public const string CreateUserQuery = "/api/v1/UserQuery/add";
        public const string GetAllUserQueries = "/api/v1/UserQuery/all";
        public const string GetAllVendorsQueries = "/api/v1/Admin/GetAllVendors";
        public const string GetUserQueryById = "/api/v1/UserQuery/{0}";
        public const string RespondToUserQuery = "/api/v1/UserQuery/respond";
        public const string IsDeleteUser = "/api/v1/Admin/IsDeleteUsers?id={0}";
        public const string IsLockedUser = "/api/v1/Admin/IsLockedUsers?id={0}";
        public const string registerVendor = "/api/v1/Account/registerVendor";
        public const string GetVendorById = "/api/v1/Vendor/{0}";
        public const string ForgotPassword = "/api/v1/Account/ForgetPassword";

        #endregion
        public const string GetChatbotResponses = "/api/v1/Chatbot/all?id={0}";


        #region Search
        public const string SearchContent = "/api/v1/Search?text={text}";
        #endregion

        #region Booking
        public const string GetAllBookings = "/api/v1/Booking";
        public const string AddBooking = "/api/v1/Booking";
        public const string GetBookingById = "/api/v1/Booking/{0}";
        public const string EditBooking = "/api/v1/Booking";
        #endregion


        public const string DeleteBannerById = "/api/v1/Banner/{0}";

        #region -Campsites
        public const string GetAllContactUs = "/api/v1/ContactUs/all";
        public const string AddContact = "/api/v1/ContactUs";

        public const string AddCampsite = "/api/v1/Campsite";
        public const string ShowCampsite = "/api/v1/Campsite/all";
        public const string EditCampsite = "/api/v1/Campsite/UpdateById";
        public const string GetById = "/api/v1/Campsite/{0}";
        public const string DeleteById = "/api/v1/Campsite/{0}";
        #endregion

        public const string GetAllCampsiteDetails = "/api/v1/CampsiteDetails/all";
        public const string GetDetailsById = "/api/v1/CampsiteDetails/{0}";
        public const string AddCampsiteDetails = "/api/v1/CampsiteDetails";
        public const string EditCampsiteDetails = "/api/v1/CampsiteDetails/UpdateCampsiteById";
        public const string DeleteCampsiteById = "/api/v1/CampsiteDetails/{0}";

        public const string GetAllCategories = "/api/v1/Category/all";

        public const string GetAllActivities = "/api/v1/Activities/all";

        public const string GetCampsiteDetailLocationsById = "/api/v1/CampsiteDetails/Campsite/{0}";
        public const string GetCampsiteForAdmin = "/api/v1/CampsiteDetails/allAdmin";


        #region -User
        public const string GetUserById = "/api/v1/User/{0}";
        public const string UpdateProfile = "/api/v1/User/edit-profile";

        #endregion

        #region Location

        public const string GetAllLocation = "/api/v1/Location/all";
        #endregion

        public const string AddReviews = "/api/v1/Reviews";
        public const string GetAllReview = "/api/v1/Reviews/allReview";
        public const string GetReviewbyId = "/api/v1/Reviews/{0}";
        public const string UpdateReview= "/api/v1/Reviews/UpdateReviewById";

        public const string AddReviewReply = "/api/v1/ReviewReply";
        public const string GetReplyById = "/api/v1/ReviewReply/{0}";
        public const string GetAllReply = "/api/v1/ReviewReply/allReply";

        public const string GetAllTents = "/api/v1/Tent/allTent";
        #region Vendor
        public const string GetVendorDetails = "/api/v1/Vendor/{0}";
        public const string UpdateVendorProfile = "/api/v1/Vendor/edit-profile";
        #endregion

        #region Glamping
         
        public const string GetGlampingList = "/api/Glamping/GetGlampingList";
        public const string GetGlampingById = "/api/Glamping/GetGlampingById?id={0}";

        #endregion
        public const string AddCart = "/api/v1/CartCamp/add";

        public const string GetAllCart = "/api/v1/CartCamp/GetAllCart";

        public const string DeleteCartId = "/api/v1/CartCamp/{0}";

        public const string CartById = "/api/v1/CartCamp/{0}";
    }
}
