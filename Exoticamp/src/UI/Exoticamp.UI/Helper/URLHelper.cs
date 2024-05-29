﻿namespace Exoticamp.UI.Helper
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
    }
}
