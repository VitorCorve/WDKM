using System.Collections.Generic;
using WDKM.Model.ParsersDataView.Additional;

namespace WDKM.Model.ParsersDataView.Interfaces
{
    public interface IHumanSocialNetworksDataView
    {
        SOCIAL_NETWORK Network { get; }
        string FriendsCount { get;}
        string Subscribers { get; }
        string Name { get; }
        string Surname { get; }
        string Birthday { get; }
        string Birthplace { get; }
        string LastSeen { get; }
        public List<string> Compile();
    }
}
