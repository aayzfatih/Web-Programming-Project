using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebProje5.Models;

namespace WebProje5.Controllers
{
    public class AdminController : Controller
    { 
        Context c = new Context();
       [Authorize]
        public IActionResult Index()
        {
            var degerler = c.Blogs.ToList();
            return View(degerler);
        }


        [HttpGet]
        public ActionResult YeniBlog()
        {
            return View();
        }

        [HttpPost]
        public ActionResult YeniBlog(Blog b)
        {
            c.Blogs.Add(b);
            c.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult BlogSil(int id)
        {
            var blog = c.Blogs.Find(id);
            c.Blogs.Remove(blog);
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult BlogGetir(int id)
        {
            var blog = c.Blogs.Find(id);
            return View("BlogGetir", blog);
        }

        public ActionResult BlogGuncelle(Blog yeni_blog)
        {
            var eski_blog = c.Blogs.Find(yeni_blog.ID);
            eski_blog.Aciklama = yeni_blog.Aciklama;
            eski_blog.Baslik = yeni_blog.Baslik;
            eski_blog.BlogImage = yeni_blog.BlogImage;
            eski_blog.tarih = yeni_blog.tarih;
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Yorumlar()
        {
            var yorumlar = c.Yorumlars.ToList();
            return View(yorumlar);
        }

        public ActionResult YorumSil(int id)
        {
            var blog = c.Yorumlars.Find(id);
            c.Yorumlars.Remove(blog);
            c.SaveChanges();
            return RedirectToAction("Yorumlar");
        }

        public ActionResult YorumGetir(int id)
        {
            var yorum = c.Yorumlars.Find(id);
            return View("YorumGetir", yorum);
        }

        public ActionResult YorumGuncelle(Yorumlar y)
        {
            var eski_yorum = c.Yorumlars.Find(y.Id);
            eski_yorum.KallaniciAdi = y.KallaniciAdi;
            eski_yorum.Mail = y.Mail;
            eski_yorum.Yorum = y.Yorum;
            c.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
