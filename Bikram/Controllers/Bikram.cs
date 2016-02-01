﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Net;
using HtmlAgilityPack;

namespace Bikram.Controllers
{
    public class Bikram
    {
        public static void DoTheFckinWork()
        {
            var result = GetTodaysYogaTimes(GetBikramTable());
        }
        static HtmlNode GetBikramTable()
        {

            using (WebClient client = new WebClient())
            {
                var html = new HtmlDocument();
                html.LoadHtml(new WebClient().DownloadString("http://bikram.hu/?p=orarend"));
                return html.DocumentNode.SelectSingleNode("//*[@id=\"ora\"]");
            }
        }

        static string GetTodaysYogaTimes(HtmlNode table)
        {
            
            int numOfDay = (int) DateTime.Today.DayOfWeek + 1;
            

            var startTimes = table.SelectNodes(".//tr/td[1]");
            var todayColumn = table.SelectNodes(".//tr/td[" + numOfDay + "]");

            List<string> startList = new List<string>();
            startList.AddRange(startTimes.Select(n => n.InnerText));

            List<string> todayList = new List<string>();
            todayList.AddRange(todayColumn.Select(n => n.InnerText));


            foreach (var item in todayList)
            {
                
            }
            
           
           

            



            return " ";
        }

        
    }
}