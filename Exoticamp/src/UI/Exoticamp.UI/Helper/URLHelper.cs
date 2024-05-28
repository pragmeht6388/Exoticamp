namespace Exoticamp.UI.Helper
{
    public static class URLHelper
    {
        #region - Events


        public const string GetAllEvents = "/api/v1/Events";

        #endregion
        public const string GetAllBanners = "/api/v1/Banner/all";

        public const string AddBanners = "/api/v1/Banner";

        public const string UpdateBanners = "/api/v1/Banner/UpdateBanner";

        public const string GetbyId = "/api/v1/Banner/{0}";

        public const string DeleteBannerById = "/api/v1/Banner/{0}";
    }
}
