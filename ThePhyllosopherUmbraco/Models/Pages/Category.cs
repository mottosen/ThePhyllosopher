using Umbraco.Cms.Core.Models.PublishedContent;
using Umbraco.Cms.Web.Common.PublishedModels;

namespace ThePhyllosopherUmbraco.Models.Pages
{
    public class Category : PageBase
    {
        readonly PageCategory node;

        public Category(PageCategory node) : base(node)
        {
            this.node = node;
        }

        public string CategoryName => PageTitle;
        public IEnumerable<ArticleBase> CategoryItems =>
            Page
            .Children()
            .Select<IPublishedContent, ArticleBase>(item =>
                {
                    if (item.ContentType.Alias == "pageTextArticle")
                    {
                        return new TextArticle(item as PageTextArticle);
                    }
                    else if (item.ContentType.Alias == "pageMediaArticle")
                    {
                        return new MediaArticle(item as PageMediaArticle);
                    }
                    else
                    {
                        return null;
                    }
                });
        public IEnumerable<ArticleBase> LatestArticles => CategoryItems.OrderByDescending(item => item.Date);
    }
}
