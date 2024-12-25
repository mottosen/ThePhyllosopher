using Umbraco.Cms.Web.Common.PublishedModels;

namespace ThePhyllosopherUmbraco.Models.Elements
{
    public class FeaturedCarousel
    {
        BlockListItemFeaturedCarousel _block;

        public FeaturedCarousel(BlockListItemFeaturedCarousel block)
        {
            this._block = block;
        }

        public IEnumerable<FeaturedLink> Links => _block.FeaturedLinks?.Select(link => new FeaturedLink(link.Content as BlockListItemFeaturedLink)) ?? [];
    }
}
