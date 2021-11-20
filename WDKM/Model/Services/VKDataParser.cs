using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using WDKM.Model.ParsersDataView;
using WDKM.Model.ParsersDataView.Additional;

namespace WDKM.Model.Services
{
    public class VKDataParser
    {
        private static HttpResponseMessage Response;
        public static List<string> GetData(string urlBody)
        {
            string url = $"https://m.vk.com/{urlBody}?act=info";

            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

            try
            {
                HttpClientHandler handler = new HttpClientHandler();
                HttpClient client = new HttpClient(handler);
                Response = client.GetAsync(url).Result;
            }
            catch (Exception)
            {
                return new List<string> { "New settings requested." };
            }


            if (Response.IsSuccessStatusCode)
            {
                string[] name = new string[2];
                var html = Response.Content.ReadAsStringAsync().Result;
                HtmlDocument document = new HtmlDocument();
                document.LoadHtml(html);

                if (!Response.IsSuccessStatusCode) return new List<string> { $"{Response.StatusCode}" };

                try
                {
                    name = document.DocumentNode.SelectSingleNode("//*[@id=\"mcont\"]/div/div/div[1]/div/h2").InnerText.Split(" ");
                }
                catch (Exception)
                {
                    name[0] = "Access denied";
                    name[1] = "Access denied";
                }
                string birthday;
                try
                {
                    birthday = document.DocumentNode.SelectSingleNode("//*[@id=\"mcont\"]/div/div/div[2]/div[1]/div[2]/div[2]/div/div[2]").InnerText;
                }
                catch (Exception)
                {
                    birthday = "Access denied";
                }
                string birthplace;
                try
                {
                    birthplace = document.DocumentNode.SelectSingleNode("//*[@id=\"mcont\"]/div/div/div[2]/div[1]/div[2]/div[1]/a/div[2]").InnerText;
                }
                catch (Exception)
                {
                    birthplace = "Access denied";
                }
                string lastSeen;
                try
                {
                    lastSeen = document.DocumentNode.SelectSingleNode("//*[@id=\"mcont\"]/div/div/div[1]/div/div").InnerText.Replace("\n", "");

                    if (lastSeen.Length == 1) lastSeen = "Access denied";
                }
                catch (Exception)
                {
                    lastSeen = "Access denied";
                }
                string subscribers;
                try
                {
                    subscribers = document.DocumentNode.SelectSingleNode("//*[@id=\"mcont\"]/div/div/div[2]/div[1]/div[2]/div[3]/a/div[2]").InnerText.Replace("подписчиков", ""); ;
                }
                catch (Exception)
                {

                    subscribers = "Access denied";
                }
                string friends;
                try
                {
                    friends = document.DocumentNode.SelectSingleNode("//*[@id=\"mcont\"]/div/div/div[1]/div[1]/div[3]/div[1]/div/div[2]/a").InnerText;
                }
                catch (Exception)
                {
                    friends = "Access denied";
                }

                return Build(name[0], name[1], birthday, birthplace, lastSeen, subscribers, friends, SOCIAL_NETWORK.VK);
            }
            return new List<string> { "\n404\n" };
        }
        private static List<string> Build(string name, string surname, string birthday, string birthPlace, string lastSeen, string subscribers, string friends, SOCIAL_NETWORK network)
        {
            VKDataView dataView = new VKDataView();
            dataView.Name = name;
            dataView.Surname = surname;
            dataView.Birthday = birthday;
            dataView.Birthplace = birthPlace;
            dataView.LastSeen = lastSeen;
            dataView.Subscribers = subscribers;
            dataView.FriendsCount = friends;
            dataView.Network = network;

            return dataView.Compile();
        }
    }
}
