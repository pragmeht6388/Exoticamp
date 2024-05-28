namespace Exoticamp.UI.Helper
{
    public static class URLHelper
    {
        #region - Events


        public const string GetAllEvents = "/api/v1/Events";

        #endregion

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
