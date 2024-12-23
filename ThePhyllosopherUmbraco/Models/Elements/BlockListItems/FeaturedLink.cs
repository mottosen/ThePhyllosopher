using Umbraco.Cms.Core.Models;
using Umbraco.Cms.Web.Common.PublishedModels;

namespace ThePhyllosopherUmbraco.Models.Elements
{
    public class FeaturedLink
    {
        BlockListItemFeaturedLink node;

        public FeaturedLink(BlockListItemFeaturedLink node)
        {
            this.node = node;
        }

        public string LinkTitle => string.IsNullOrWhiteSpace(node.LinkTitle) ? "" : node.LinkTitle;
        public Link? Link => node.Link;
        public MediaWithCrops? LinkImage => node.LinkImage;
    }
}
