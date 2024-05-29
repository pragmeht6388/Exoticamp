namespace Exoticamp.UI.Helper
{
    public static class URLHelper
    {
        #region - Events


        public const string GetAllEvents = "/api/v1/Events";
        public const string Registration = "/api/v1/Account/register";
        public const string Login = "/api/v1/Account/authenticate";
        public const string GetAllUsers = "/api/v1/Admin/GetAllUsers";
        #endregion
        public const string GetAllBanners = "/api/v1/Banner/all";

        public const string AddBanners = "/api/v1/Banner";

        public const string UpdateBanners = "/api/v1/Banner/UpdateBanner";

        public const string GetbyId = "/api/v1/Banner/{0}";

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
    }
}
