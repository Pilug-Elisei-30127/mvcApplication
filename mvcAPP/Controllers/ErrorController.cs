﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace mvcAPP.Controllers
{
    public class ErrorController : Controller
    {
        public ActionResult  NotFound404()
        {
            return View("NotFound404");
        }
    }
}