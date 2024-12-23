using Umbraco.Cms.Core.Models;
using Umbraco.Cms.Core.Models.Blocks;
using Umbraco.Cms.Web.Common.PublishedModels;

namespace ThePhyllosopherUmbraco.Models.Pages
{
    public class TextArticle : ArticleBase
    {
        readonly PageTextArticle node;

        public TextArticle(PageTextArticle node) : base(node)
        {
            this.node = node;
        }

        public MediaWithCrops? ArticleImage => node.ArticleImage;
        public BlockListModel? ArticleBlocks => node.ArticleBlocks;
    }
}
