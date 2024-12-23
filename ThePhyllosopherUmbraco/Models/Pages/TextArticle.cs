using Umbraco.Cms.Core.Models;
using Umbraco.Cms.Core.Models.Blocks;
using Umbraco.Cms.Web.Common.PublishedModels;

namespace ThePhyllosopherUmbraco.Models.Pages
{
    public class TextArticle
    {
        PageTextArticle node;

        public TextArticle(PageTextArticle node)
        {
            this.node = node;
        }

        public PageTextArticle Page => node;
        public string ArticleTitle => string.IsNullOrWhiteSpace(node.ArticleTitle) ? node.Name : node.ArticleTitle;
        public MediaWithCrops? ArticleImage => node.ArticleImage;
        public DateTime Date => node.Date == default ? node.UpdateDate : node.Date;
        public Employee Author => new Employee(node.Author as PageEmployee);
        public Category Category => new Category(node.Parent as PageCategory);
        public BlockListModel? ArticleBlocks => node.ArticleBlocks;
    }
}
