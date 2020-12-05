using CCA.Util;
using WServices.ViewModel;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web.Mvc;
using System;
using Newtonsoft.Json.Linq;

namespace WServices.Controllers
{
    public class HomeController : Controller
    {


        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }


    }
}
