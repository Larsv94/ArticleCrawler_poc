using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using ArticleCrawler_poc.Objects;

namespace ArticleCrawler_poc
{
    class Crawler
    {
        private readonly string offsetURL = "https://80.lv/wp-content/themes/80lvl%20-%20Vitamin/ajax/index-ajax.php?&sort=&offset={0}";
        private HtmlWeb _webReader;
        private string BaseURL;
        
        public HtmlWeb WebReader
        {
            get { return _webReader ?? (_webReader = new HtmlWeb()); }
        }
        

        public void StartCrawling(int depth)
        {
            var process = Crawl(0,depth);
            process.Wait();
        }

        private async Task Crawl(int offset, int depth)
        {
            if (offset<=depth)
            {
                Console.WriteLine($"Checking offset {offset}");
                DateTime date = DateTime.Now.AddDays(-20);//TODO: get latest date from database
                string url = String.Format(offsetURL, offset);
                HtmlDocument document = WebReader.Load(url);
                var scrapeTargets = getScrapTargets(document,date);
                if (scrapeTargets.Count>0)//TODO: get latest date from database
                {
                    var recursive = Crawl(offset + 20, depth);
                    List<Task> runningTasks = new List<Task>();
                    foreach (ScrapeTarget target in scrapeTargets)
                    {
                        Console.WriteLine($"##{offset}## Fetching {target.url}....");
                        runningTasks.Add(ScrapAsync(target,offset));
                    }
                    
                    await Task.WhenAll(runningTasks);
                    await recursive;
                }

            }
        }

        private async Task ScrapAsync(ScrapeTarget target,int offset)
        {
            await Task.Delay(new Random().Next(3000,6000));
            Console.WriteLine($"!!!!!##{offset}##Done fetching {target.url}....");
        }

        private List<ScrapeTarget> getScrapTargets(HtmlDocument document, DateTime date)
        {
            var articleCards = document.DocumentNode.Descendants("div").Where(x => x.HasClass("column_element")).Select(y => y);
            return articleCards.Select(item =>
                new ScrapeTarget
                {
                    url = item.Descendants("a")
                            .Where(a => a.Attributes.Contains("href"))
                            .Select(link => link.Attributes["href"]
                            .Value).Distinct().FirstOrDefault()

                  ,
                    date = DateTime.Parse(item.Descendants("p")
                            .Where(paragraph => paragraph.HasClass("date"))
                            .FirstOrDefault().InnerHtml)
                })
                .Where(target => target.date > date)
                .ToList();
        }
    }
}
