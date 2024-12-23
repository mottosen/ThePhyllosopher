using ThePhyllosopherUmbraco.Models.Elements;
using Umbraco.Cms.Core.Models.Blocks;
using Umbraco.Cms.Web.Common.PublishedModels;

namespace ThePhyllosopherUmbraco.Models.Pages
{
    public class Home : PageBase
    {
        readonly PageHome node;

        public Home(PageHome node) : base(node)
        {
            this.node = node;
        }
        
        public string SiteName => string.IsNullOrWhiteSpace(node.SiteName) ? PageTitle : node.SiteName;
        public IEnumerable<FooterLinks> FooterLinks => node.FooterLinks?.Select(block => new FooterLinks(block.Content as ElementFooterLinks)) ?? [];
        public string FooterNote => string.IsNullOrWhiteSpace(node.ShortNote) ? "" : node.ShortNote;
        public BlockListModel? ContentBlocks => node.Blocks;
    }
}
