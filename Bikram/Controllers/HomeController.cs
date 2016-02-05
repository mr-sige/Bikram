using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Bikram.Models;

namespace Bikram.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var result = Bikram.DoTheFckinWork();
            return View(new BikramViewModel(result));
        }
    }
}