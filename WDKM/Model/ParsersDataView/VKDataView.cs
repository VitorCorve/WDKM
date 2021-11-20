using System.Collections.Generic;
using WDKM.Model.ParsersDataView.Additional;
using WDKM.Model.ParsersDataView.Interfaces;

namespace WDKM.Model.ParsersDataView
{
    public class VKDataView : IHumanSocialNetworksDataView
    {
        public string FriendsCount { get; set; }
        public string Subscribers { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Birthday { get; set; }
        public string Birthplace { get; set; }
        public string LastSeen { get; set; }
        public SOCIAL_NETWORK Network { get; set; }
        public List<string> Compile()
        {
            var result = new List<string>();
            result.Add($"\nNetwork: {Network}\n");
            result.Add($"Name: {Name}\n");
            result.Add($"Surname: {Surname}\n");
            result.Add($"Birthday: {Birthday}\n");
            result.Add($"Birthplace: {Birthplace}\n");
            result.Add($"Friends: {FriendsCount}\n");
            result.Add($"Last seen: {LastSeen}\n");
            result.Add($"Subscribers: {Subscribers}\n");
            return result;
        }
    }
}
