using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;

namespace WDKM.Model.Services
{
    public class NewsParser
    {
        public static List<string> GetData()
        {
            string url = "https://m.vk.com/lentach";

            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

            try
            {
                HttpClientHandler handler = new HttpClientHandler();
                HttpClient client = new HttpClient(handler);
                HttpResponseMessage response = client.GetAsync(url).Result;

                var data = new List<string>();
                if (response.IsSuccessStatusCode)
                {
                    var html = response.Content.ReadAsStringAsync().Result;
                    HtmlDocument document = new HtmlDocument();
                    document.LoadHtml(html);
                    var result = document.DocumentNode.SelectNodes("//div[@class='pi_text']");
                    var postDate = document.DocumentNode.SelectNodes("//div[@class='wi_info']");

                    int countdown = 0;
                    foreach (var item in result)
                    {
                        data.Add("\t" + postDate[countdown].InnerText);
                        data.Add("\t" + item.InnerText.Replace("&#", "\n") + "\n\n");
                        countdown++;
                    }
                    return data;

                }
            }
            catch (Exception)
            {

                return new List<string> { "New settings requested." };
            }
            return null;
        }
    }
}
