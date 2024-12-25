using Umbraco.Cms.Core.Models.Blocks;
using Umbraco.Cms.Web.Common.PublishedModels;

namespace ThePhyllosopherUmbraco.Models.Pages
{
    public class About : PageBase
    {
        readonly PageAbout _node;

        public About(PageAbout node) : base(node)
        {
            _node = node;
        }

        public BlockListModel? ContentBlocks => _node.Blocks;
    }
}
