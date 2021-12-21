using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using WebProje5.Models;

namespace WebProje5.Controllers
{
    public class LoginController : Controller
    {
        public object FormsAuthentication { get; private set; }
        public object Session { get; private set; }

        Context c = new Context();
        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public IActionResult AdminLogin()
        {
            return View();
        }

        public async Task<IActionResult> AdminLogin(Admin p)
        {
            var bilgiler = c.Admins.FirstOrDefault(x => x.kullanici == p.kullanici && x.sifre == p.sifre);
            if(bilgiler != null)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, p.kullanici)
                };
                var useridentity = new ClaimsIdentity(claims, "Login");
                ClaimsPrincipal principal = new ClaimsPrincipal(useridentity);
                await HttpContext.SignInAsync(principal);
                return RedirectToAction("Index", "Admin");
            }
            return View();
        }

       
        [HttpPost]
        public async Task<IActionResult> SignOutAsync()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            return RedirectToAction("AdminLogin", "Login");
        }
        
        public IActionResult CikisYap()
        {
            SignOutAsync();
            return RedirectToAction("AdminLogin", "Login");
        }

        [HttpGet]
        public IActionResult KullanıcıGiris()
        {
            return View();
        }

        [HttpPost]
        public IActionResult KullanıcıGiris(Kullanici k)
        {
            var bilgiler = c.Kullanicis.FirstOrDefault(x => x.kullanici_adi == k.kullanici_adi && x.Sifre == k.Sifre);
            if (bilgiler != null)
            {
                var id = bilgiler.ID;
                HttpContext.Session.SetString("UserID",  id.ToString());
                 return RedirectToAction("kullaniciblog", "kullaniciBlog");
            }
            return View();
        }

        [HttpGet]
        public IActionResult YeniKullanıci()
        {
            return View();
        }

        [HttpPost]
        public IActionResult YeniKullanıci(Kullanici k)
        {
            c.Kullanicis.Add(k);
            c.SaveChanges();
            return RedirectToAction("KullanıcıGiris", "Login");

        }

    }
}
