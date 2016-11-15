using System.Collections.Generic;
using System.Web.Mvc;
using Bikram.Models;

namespace Bikram.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            List<string> today = Bikram.GetTodaysClasses();
            List<string> tomorrow = Bikram.GetTomorrowsClasses(); 
            return this.View(new BikramViewModel(today, tomorrow));
        }
    }
}