using Umbraco.Cms.Core.Models.Blocks;
using Umbraco.Cms.Web.Common.PublishedModels;

namespace ThePhyllosopherUmbraco.Models.Pages
{
    public class MediaArticle : ArticleBase
    {
        PageMediaArticle _node;

        public MediaArticle(PageMediaArticle node) : base(node)
        {
            _node = node;
        }

        public string MediaLink => string.IsNullOrWhiteSpace(_node.MediaLink) ? "" : _node.MediaLink;
        public BlockListModel? ArticleBlocks => _node.ArticleBlocks;
    }
}
