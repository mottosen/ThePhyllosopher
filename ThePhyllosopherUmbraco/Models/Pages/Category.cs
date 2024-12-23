using Umbraco.Cms.Core.Models.PublishedContent;
using Umbraco.Cms.Web.Common.PublishedModels;

namespace ThePhyllosopherUmbraco.Models.Pages
{
    public class Category
    {
        PageCategory node;

        public Category(PageCategory node)
        {
            this.node = node;
        }

        public PageCategory Page => node;
        public IPublishedContent[] CategoryItems => Page.Children().ToArray();
        public string Name => "";// string.IsNullOrWhiteSpace(node.CategoryName) ? node.Name : node.CategoryName;
	}
}
