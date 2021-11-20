using HtmlAgilityPack;
using System;
using System.Net;
using System.Net.Http;

namespace WDKM.Model.Services
{
    public class BitcoinCourseParser
    {
        public static string GetCourse()
        {
            string url = "https://mainfin.ru/crypto/bitcoin";

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
                    var result = document.DocumentNode.SelectSingleNode("/html/body/div[5]/div/div[1]/div/div[2]/div[2]/div[1]/div").InnerText;
                    return result.ToString().Replace(".", " . ").Replace("$", " $ ");

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
