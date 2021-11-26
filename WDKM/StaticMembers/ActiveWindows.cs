using System.Collections.Generic;
using System.Windows;
using System.Linq;

namespace WDKM.StaticMembers
{
    public class ActiveWindows
    {
        private static ICollection<Window> Windows { get; set; } = new List<Window>();
        public static void Close(string windowName)
        {
            switch (windowName)
            {
                case "video":
                    var window = Windows.Where(x => x.Name is "video").First();
                    window.Close();
                    return;
                default:
                    return;
            }
        }
        public static void Add(Window window) => Windows.Add(window);
    }
}
