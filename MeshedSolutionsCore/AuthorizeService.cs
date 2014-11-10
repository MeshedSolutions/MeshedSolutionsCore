using System.Web;
using System.Web.Mvc;


namespace MeshedSolutionsCore
{
    public class CustomAuthorize : AuthorizeAttribute
    {
        public string ApplicationName { get; set; }

        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            int userID = 0;

            var cookieValue = CookieService.GetCookie(HttpContext.Current, ApplicationName, "UserID");
            if (cookieValue != null)
                userID = int.Parse(cookieValue);

            return userID != 0;
        }
    }
}
