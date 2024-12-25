using Umbraco.Cms.Web.Common.PublishedModels;

namespace ThePhyllosopherUmbraco.Models.Pages
{
    public class Blog : PageBase
    {
        readonly PageBlog _node;

        public Blog(PageBlog node) : base(node)
		{
			this._node = node;
		}

		public IEnumerable<Category> Categories => _node.Children<PageCategory>()?.Select(x => new Category(x)) ?? [];
	}
}
