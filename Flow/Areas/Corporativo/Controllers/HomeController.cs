﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Flow.Areas.Corporativo.Controllers
{
    public class HomeController : Controller
    {
        // GET: Corporativo/Home
        public ActionResult Index()
        {
            return View();
        }
    }
}