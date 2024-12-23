using ThePhyllosopherUmbraco.Models.Pages;
using Umbraco.Cms.Core.Models;
using Umbraco.Cms.Core.Models.PublishedContent;
using Umbraco.Cms.Web.Common.PublishedModels;

namespace ThePhyllosopherUmbraco.Models
{
    public class ArticleBase : PageBase
    {
        IPublishedContent node;

        public ArticleBase(IPublishedContent node) : base(node)
        {
            this.node = node;
        }

        private IArticleProperties Article => node as IArticleProperties;

        // Article Content
        public string ArticleTitle => string.IsNullOrWhiteSpace(Article.ArticleTitle) ? node.Name : Article.ArticleTitle;
        public DateTime Date => Article.Date == default ? node.UpdateDate : Article.Date;
        public Employee Author => new Employee(Article.Author as PageEmployee);
        public Category Category => new Category(node.Parent as PageCategory);

        // Article Card
        public string CardTitle => string.IsNullOrWhiteSpace(Article.CardTitle) ? ArticleTitle : Article.CardTitle;
        public string CardDescription => string.IsNullOrWhiteSpace(Article.CardDescription) ? "" : Article.CardDescription;
        public MediaWithCrops? CardImage => Article.CardImage;
    }
}
