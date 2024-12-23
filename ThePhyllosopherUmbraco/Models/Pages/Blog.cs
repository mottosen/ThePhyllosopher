using Umbraco.Cms.Web.Common.PublishedModels;

namespace ThePhyllosopherUmbraco.Models.Pages
{
    public class Blog : PageBase
    {
        readonly PageBlog node;

        public Blog(PageBlog node) : base(node)
		{
			this.node = node;
		}

		public IEnumerable<Category> Categories => node.Children<PageCategory>()?.Select(x => new Category(x)) ?? [];
	}
}
