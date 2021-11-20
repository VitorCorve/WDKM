using System.Collections.Generic;

namespace WDKM.Model.Services
{
    public class AvailableCommandsListBuilder
    {
        public static List<string> Build()
        {
            var list = new List<string>();
            list.Add("\navail\t - \tGet available commands list");
            list.Add("\nbtc\t - \tGet Bitcoun course");
            list.Add("\nusd\t - \tGet USD course");
            list.Add("\neur\t - \tGet EUR course");
            list.Add("\neth\t - \tGet Etherium course");
            list.Add("\nof\t - \tOpen file dialog");
            list.Add("\nex\t - \tExit");
            list.Add("\ntime\t - \tGet current local date");
            list.Add("\nvcn\t - \tView all courses");
            list.Add("\nnews\t - \tGet actual news list");
            list.Add("\nout\t - \tShutdown system");
            list.Add("\nreb\t - \tReboot system");
            list.Add("\nvkp\t - \tParse VK user info by ID. Syntax: vkp id1");
            list.Add("\nwiki\t - \tGet wiki article. Use 'wiki article full' - to see full article");

            return list;
        }
    }
}
