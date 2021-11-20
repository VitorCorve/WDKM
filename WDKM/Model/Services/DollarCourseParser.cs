using HtmlAgilityPack;
using System;
using System.Net;
using System.Net.Http;

namespace WDKM.Model.Services
{
    public class DollarCourseParser
    {
        public static string GetCourse()
        {
            string url = "https://mainfin.ru/currency/usd";

            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

            try
            {
                HttpClientHandler handler = new HttpClientHandler();
                HttpClient client = new HttpClient(handler);
                HttpResponseMessage response = client.GetAsync(url).Result;

                if (response.IsSuccessStatusCode)
                {
                    var html = response.Content.ReadAsStringAsync().Result;
                    HtmlDocument document = new HtmlDocument();
                    document.LoadHtml(html);
                    var result = document.DocumentNode.SelectSingleNode("//*[@id=\"buy_usd\"]").InnerText;
                    return result.ToString().Replace(".", " . ") + " $ ";

                }
            }
            catch (Exception)
            {

                return "New settings requested.";
            }
            return null;
        }
    }
}
