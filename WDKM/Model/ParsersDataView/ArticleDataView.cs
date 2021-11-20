using System.Collections.Generic;
using WDKM.Model.ParsersDataView.Interfaces;

namespace WDKM.Model.ParsersDataView
{
    public class ArticleDataView : IArticleDataView
    {
        public string Title { get; set; }

        public string Content { get; set; }
        public ArticleDataView(string title, string content)
        {
            Title = title;
            Content = content;
        }
        public List<string> BuildArticleView() => new List<string> { Title + "\n", Content + "\n" };
    }
}
