using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Localization;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using WebProje5.Models;

namespace WebProje5.Controllers
{
    public class HomeController : Controller
    {
        private readonly IHtmlLocalizer<HomeController> _localizer;

        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, IHtmlLocalizer<HomeController> localizer)
        {
            _logger = logger;
            _localizer = localizer;
        }
        Context c = new Context();
        public IActionResult Index()
        {
            var degerler1 = c.Blogs.OrderByDescending(x => x.ID).Take(2).ToList();
            return View(degerler1);
        }

        public IActionResult Privacy()
        {
            return View();
        }


        [HttpPost]
        public IActionResult CultureManagement(string culture, string returnUrl)
        {
            Response.Cookies.Append(CookieRequestCultureProvider.DefaultCookieName, CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture)),
                new CookieOptions { Expires = DateTimeOffset.Now.AddDays(30) });

            return LocalRedirect(returnUrl);
        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
