using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;


namespace Blazor.I18N.Bug.Data
{
    [Route("[controller]/[action]")]
    public class CultureController : Controller
    {
        public IActionResult SetCulture(string culture, string redirectUri)
        {
            if (culture != null)
            {
                var requestCulture = new RequestCulture(culture, culture);

                HttpContext.Response.Cookies.Append(
                    CookieRequestCultureProvider.DefaultCookieName,
                    CookieRequestCultureProvider.MakeCookieValue(requestCulture));

            }

            return LocalRedirect(redirectUri);
        }
    }
}
