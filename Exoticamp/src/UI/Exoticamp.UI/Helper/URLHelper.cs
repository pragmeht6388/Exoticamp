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
        public const string CreateUserQuery = "/api/v1/UserQuery/add";
        public const string GetAllUserQueries = "/api/v1/UserQuery/all";
        public const string GetUserQueryById = "/api/v1/UserQuery/{0}";
        public const string RespondToUserQuery = "/api/v1/UserQuery/respond";
        public const string GetChatbotResponses = "/api/v1/Chatbot/all?id={0}";






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


        public const string GetAllCategories = "/api/v1/Category/all";

    }
}
