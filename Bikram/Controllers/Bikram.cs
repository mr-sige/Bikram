using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Net;
using Antlr.Runtime.Misc;
using HtmlAgilityPack;

namespace Bikram.Controllers
{
	public class Bikram
	{
		public static List<string> GetTodaysClasses()
		{

			return GetClassesForDay(GetNumberOfToday());
		}

		public static List<string> GetTomorrowsClasses()
		{
			int today = GetNumberOfToday();
			int tomorrow = today + 1;
			if (tomorrow == 8)
			{
				tomorrow = 1;
			}

			return GetClassesForDay(tomorrow);
		}

		static int GetNumberOfToday()
		{
			int today = (int)DateTime.Today.DayOfWeek;

			if (today.Equals(0))
			{
				today = today + 7; //because Sunday is the first day
			}
			return today;
		}

		static List<string> GetClassesForDay(int numOfDay)
		{
			HtmlNode table;
			using (WebClient client = new WebClient())
			{
				HtmlDocument html = new HtmlDocument();
				html.LoadHtml(new WebClient().DownloadString("http://bikram.hu/?p=orarend"));
				table = html.DocumentNode.SelectSingleNode("//*[@id=\"ora\"]");
			}


			var startTimes = table.SelectNodes(".//tr/td[1]");
			var todayColumn = table.SelectNodes($".//tr/td[" + numOfDay + 1 + "]");

			List<string> startList = new List<string>();
			startList.AddRange(startTimes.Select(n => n.InnerText));

			List<string> todayList = new List<string>();
			todayList.AddRange(todayColumn.Select(n => n.InnerText));

			List<string> result = new ListStack<string>();

			for (int i = 0; i < startList.Count; i++)
			{
				startList[i] = startList[i].Replace(".", ":");
			}

			for (int i = 0; i < todayList.Count; i++)
			{
				if (todayList[i] != "&nbsp;")
				{
					result.Add(String.Concat(startList[i], " ", todayList[i]));
				}
			}

			return result;
		}
	}
}