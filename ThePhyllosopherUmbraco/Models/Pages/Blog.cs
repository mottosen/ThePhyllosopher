using Umbraco.Cms.Web.Common.PublishedModels;

namespace ThePhyllosopherUmbraco.Models.Pages
{
    public class Blog
    {
        PageBlog node;

        public Blog(PageBlog node)
		{
			this.node = node;
		}

		public PageBlog Page => node;
		public Category[] Categories => node.Children<PageCategory>()?.Select(x => new Category(x)).ToArray() ?? [];
	}
}
