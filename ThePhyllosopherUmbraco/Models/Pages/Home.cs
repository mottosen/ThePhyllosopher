using ThePhyllosopherUmbraco.Models.Elements;
using Umbraco.Cms.Core.Models;
using Umbraco.Cms.Core.Models.Blocks;
using Umbraco.Cms.Web.Common.PublishedModels;

namespace ThePhyllosopherUmbraco.Models.Pages
{
    public class Home : PageBase
    {
        readonly PageHome _node;

        public Home(PageHome node) : base(node)
        {
            this._node = node;
        }

        public BlockListModel? ContentBlocks => _node.Blocks;
        
        public string SiteName => string.IsNullOrWhiteSpace(_node.SiteName) ? PageTitle : _node.SiteName;
        public IEnumerable<FooterLinks> FooterLinks => _node.FooterLinks?.Select(block => new FooterLinks(block.Content as ElementFooterLinks)) ?? [];
        public string FooterNote => string.IsNullOrWhiteSpace(_node.ShortNote) ? "" : _node.ShortNote;
        public IEnumerable<ArticleBase> AllArticles =>
            _node.Children<PageBlog>()?.Select(node => new Blog(node))
            .SelectMany(blog => blog.Categories
                .SelectMany(category => category.LatestArticles)) ?? [];
        public IEnumerable<Link> SocialLinks => _node.SocialLinks ?? [];
    }
}
