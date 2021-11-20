
using System.Collections.Generic;

namespace WDKM.Model.ParsersDataView.Interfaces
{
    public interface IArticleDataView
    {
        string Title { get; }
        string Content { get; }
        List<string> BuildArticleView();
    }
}
