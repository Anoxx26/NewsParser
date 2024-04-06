using HtmlAgilityPack;

namespace NewsParser.Parser
{
    public class LentaParser
    {
        private string baseUrl = "https://lenta.ru/parts/news/";

        private HtmlWeb web = new HtmlWeb();
        private HtmlDocument htmlDoc = new HtmlDocument();

        public List<string> GetLinkNews()
        {
            List<string> newsList = new List<string>();

            string newsPath = "//a[@class='card-full-news _parts-news']";

            htmlDoc.LoadHtml(web.Load(baseUrl).Text);

            var node = htmlDoc.DocumentNode.SelectNodes(newsPath);

            if (node == null)
            {
                throw new Exception();
            }

            foreach (var news in node)
            {
                newsList.Add("https://lenta.ru" + news.GetAttributeValue("href", ""));
            }

            return newsList;
        }
    }
}
