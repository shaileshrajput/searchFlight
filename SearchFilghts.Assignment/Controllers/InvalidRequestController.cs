﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SearchFilghts.Assignment.Controllers
{
    public class InvalidRequestController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Error()
        {
            return View();
        }

    }
}
