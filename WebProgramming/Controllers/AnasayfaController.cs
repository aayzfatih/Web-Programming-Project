using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebProje5.Models;

namespace WebProje5.Controllers
{
    public class AnasayfaController : Controller
    {
        Context c = new Context();
        public IActionResult Index()
        {
            var degerler = c.Blogs.Take(4).ToList();
            return View(degerler);
        }

        public PartialViewResult Partial1()
        {
            var degerler1 = c.Blogs.OrderByDescending(x => x.ID).Take(2).ToList();
            return PartialView(degerler1);
        }

        public PartialViewResult Partial2()
        {
            var degerler = c.Blogs.Where(x => x.ID == 3).ToList();

            return PartialView(degerler);
        }
        public PartialViewResult Partial3()
        {
            var degerler = c.Blogs.OrderByDescending(x => x.ID).Take(10).ToList();
            return PartialView(degerler);
        }
        public PartialViewResult Partial4()
        {
            var degerler = c.Blogs.OrderByDescending(x => x.ID).Take(3).ToList();
            return PartialView(degerler);
        }
        public PartialViewResult Partial5()
        {
            var degerler = c.Blogs.OrderBy(x => x.ID).Take(3).ToList();
            return PartialView(degerler);
        }

        public IActionResult Hakkinda()
        {
            return View();
        }
    }
}
