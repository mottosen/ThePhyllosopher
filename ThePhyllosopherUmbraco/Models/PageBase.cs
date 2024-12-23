using Umbraco.Cms.Core.Models.PublishedContent;
using Umbraco.Cms.Web.Common.PublishedModels;

namespace ThePhyllosopherUmbraco.Models
{
    public abstract class PageBase
    {
        readonly IPublishedContent node;

        public PageBase(IPublishedContent node)
        {
            this.node = node;
        }

        // Base
        public IPublishedContent Page => node;
        public string PageUrl => node.Url();
        public PageHome PageHome => node.Root<PageHome>();

        // Header
        private IHeaderProperties Header => node as IHeaderProperties;
        public IEnumerable<IPublishedContent> NavigationItems => PageHome.Children();
        public string PageTitle => string.IsNullOrWhiteSpace(Header.PageTitle) ? node.Name : Header.PageTitle;
        public bool HideFromNavigation => Header.HideFromNavigation;

        // Footer
        private IFooterProperties Footer => node as IFooterProperties;
    }
}
