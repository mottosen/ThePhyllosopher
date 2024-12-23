using Umbraco.Cms.Core.Models.PublishedContent;
using Umbraco.Cms.Web.Common.PublishedModels;

namespace ThePhyllosopherUmbraco.Models.Pages
{
    public class Home
    {
        PageHome node;

        public Home(PageHome node)
        {
            this.node = node;
        }

        public PageHome Page => node;
        public IPublishedContent[] NavigationItems => Page.Children().ToArray();
    }
}
