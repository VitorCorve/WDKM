using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using WDKM.Model.ParsersDataView;

namespace WDKM.Model.Services
{
    public class WikiDataParser
    {
        public static List<string> GetData(string url, bool fullArticle)
        {
            string urlBody = "https://en.wikipedia.org/wiki/";

            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            HttpClientHandler handler = new HttpClientHandler();
            HttpClient client = new HttpClient(handler);

            try
            {
                HttpResponseMessage response = client.GetAsync(urlBody + url).Result;

                if (response.IsSuccessStatusCode)
                {
                    var html = response.Content.ReadAsStringAsync().Result;
                    HtmlDocument document = new HtmlDocument();
                    document.LoadHtml(html);
                    string title = document.DocumentNode.SelectSingleNode("//*[@id=\"firstHeading\"]").InnerText;
                    var result = document.DocumentNode.SelectNodes("//div[@class='mw-parser-output']//p");
                    string body = null;

                    if (fullArticle)
                    {
                        for (int i = 0; i < result.Count - 1; i++)
                            body += result[i].InnerText + "\n";

                        return new ArticleDataView(title, body.Replace("&#", "")).BuildArticleView();
                    }
                    else
                    {
                        body = "\n" + result[1].InnerText + "\n";
                        return new ArticleDataView(title, body.Replace("&#", "")).BuildArticleView();
                    }


                }
            }
            catch (Exception)
            {
                return new List<string> { "\nWrong URL\n" };
            }
            return new List<string> { "\n404 URL\n" };
        }
    }
}
