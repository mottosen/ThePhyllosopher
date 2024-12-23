using Umbraco.Cms.Web.Common.PublishedModels;

namespace ThePhyllosopherUmbraco.Models.Pages
{
    public class MediaArticle : ArticleBase
    {
        PageMediaArticle node;

        public MediaArticle(PageMediaArticle node) : base(node)
        {
            this.node = node;
        }
    }
}
