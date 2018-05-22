using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ArticleCrawler_poc
{
    class Crawler
    {
        private HtmlWeb _webReader;
        private string BaseURL;
        
        public HtmlWeb WebReader
        {
            get { return _webReader ?? (_webReader = new HtmlWeb()); }
        }

        public HtmlDocument BaseDocument
        {
            get { return WebReader.Load(BaseURL); }
        }

        public Crawler(String BaseURL)
        {
            this.BaseURL = BaseURL;
        }

        public async void StartCrawling(int depth)
        {
            int amount = depth % 20;
        }

    }
}
