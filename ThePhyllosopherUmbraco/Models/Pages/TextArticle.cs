using Umbraco.Cms.Core.Models;
using Umbraco.Cms.Core.Models.Blocks;
using Umbraco.Cms.Web.Common.PublishedModels;

namespace ThePhyllosopherUmbraco.Models.Pages
{
    public class TextArticle : ArticleBase
    {
        readonly PageTextArticle _node;

        public TextArticle(PageTextArticle node) : base(node)
        {
            this._node = node;
        }

        public MediaWithCrops? ArticleImage => _node.ArticleImage;
        public BlockListModel? ArticleBlocks => _node.ArticleBlocks;
    }
}
