﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebProje5.Controllers
{
    public class HakkindaController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
