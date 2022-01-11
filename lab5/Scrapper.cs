using HtmlAgilityPack;
using HtmlAgilityPack.CssSelectors.NetCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WebScrapper2
{
    internal class Scrapper
    {
        public void ScrapData()
        {
            var web = new HtmlWeb();
            var document = web.Load("https://sportowefakty.wp.pl/pilka-reczna");
            var results = document.QuerySelectorAll("table tr").Skip(1);

            foreach (var result in results)
            {
                var tds = result.QuerySelectorAll("td");
                var position = tds[0].InnerText;
                var name = tds[1].InnerText;
                var matches = tds[2].InnerText;
                var points = tds[3].InnerText;
                var wins = tds[4].InnerText;
                var losses = tds[5].InnerText;
                Console.WriteLine($"position: {position}. Name: {name} M: {matches} P: {points} W: {wins} L: {losses}");

            }
        }
    }
}
