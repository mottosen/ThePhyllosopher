using Umbraco.Cms.Core.Models.Blocks;
using Umbraco.Cms.Web.Common.PublishedModels;

namespace ThePhyllosopherUmbraco.Models.Elements
{
    public class FeaturedLinkCarousel
    {
        BlockListItemFeaturedLinkCarousel node;

        public FeaturedLinkCarousel(BlockListItemFeaturedLinkCarousel node)
        {
            this.node = node;
        }

        public FeaturedLink[] Links =>
            node.FeaturedLinks?
            .Select(blockListItem => blockListItem.Content as BlockListItemFeaturedLink)
            .WhereNotNull()
            .Select(foo => new FeaturedLink(foo))
            .ToArray() ?? [];
    }
}
