using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;

namespace Bikram.Models
{
    public class IndexViewModel
    {
       
    }

    public class BikramViewModel
    {
        public List<string> TodaysClasses { get; set; }

		public List<string> TomorrowsClasses { get; set; }

		public BikramViewModel(List<string> todaysClasses, List<string> tomorrowsClasses)
        {
            TodaysClasses = todaysClasses;
			TomorrowsClasses = tomorrowsClasses;
        }
    }
    
}