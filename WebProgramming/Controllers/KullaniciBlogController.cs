using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebProje5.Models;

namespace WebProje5.Controllers
{
    public class KullaniciBlogController : Controller
    {
        Context c = new Context();
        KullaniciBlog kb = new KullaniciBlog();
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult KullaniciBlog()
        {
           var id = HttpContext.Session.GetString("UserID");
            int temp_id = Int16.Parse(id);
           
            //  by.Deger2 = c.Yorumlars.Where(x => x.Blogid == id).ToList();
           var tmp  = c.kullaniciBlogs.Where(x => x.ID == temp_id).ToList();
           return View(tmp);
        }

    }
}
