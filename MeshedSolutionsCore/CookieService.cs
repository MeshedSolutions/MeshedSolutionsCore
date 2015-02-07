using System;
using System.Web;

namespace MeshedSolutionsCore
{
    public static class CookieService
    {
        public static string GetCookie(HttpContext context, string applicationName, string cookieName)
        {
            var httpCookie = HttpContext.Current.Request.Cookies[applicationName];
            if (httpCookie != null)
                return httpCookie[cookieName];

            return null;
        }
        public static void SetCookie(string applicationName, string cookieName, int cookieDuration, string cookieValue = "0")
        {
            var cookie = new HttpCookie(applicationName);

            cookie[cookieName] = cookieValue;
            cookie.Expires = DateTime.Now.AddDays(cookieDuration);
            HttpContext.Current.Response.Cookies.Add(cookie);
        }
        public static void SetCookie(HttpResponseBase response, string cookieName, int cookieDuration, string cookieValue = "0")
        {
            var cookie = new HttpCookie("MeatGrinder");

            cookie[cookieName] = cookieValue;
            cookie.Expires = DateTime.Now.AddDays(cookieDuration);
            response.Cookies.Add(cookie);
        }
        public static void DeleteCookie(string applicationName, string cookieName)
        {
            SetCookie(applicationName, cookieName, -1);
        }
        public static int GetUserID(string applicationName)
        {
            int userID = int.Parse(GetCookie(HttpContext.Current, applicationName, "UserID"));
            return userID;
        }

    }
}
