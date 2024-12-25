using Umbraco.Cms.Core.Models;
using Umbraco.Cms.Core.Strings;
using Umbraco.Cms.Web.Common.PublishedModels;

namespace ThePhyllosopherUmbraco.Models.Elements
{
    public class FooterLinks
    {
        ElementFooterLinks node;

        public FooterLinks(ElementFooterLinks node)
        {
            this.node = node;
        }

        public string LinksTitle => string.IsNullOrWhiteSpace(node.LinksTitle) ? "" : node.LinksTitle;
        public Link[] Links => node.FeaturedLinks?.ToArray() ?? [];
    }
}
