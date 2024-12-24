using Umbraco.Cms.Web.Common.PublishedModels;

namespace ThePhyllosopherUmbraco.Models.Elements
{
    public class FeaturedLinkSquares
    {
        BlockListItemFeaturedLinkSquares _block;

        public FeaturedLinkSquares(BlockListItemFeaturedLinkSquares block)
        {
            this._block = block;
        }

        public FeaturedLink[] Links =>
            _block.FeaturedLinks?
            .Select(blockListItem => blockListItem.Content as BlockListItemFeaturedLink)
            .WhereNotNull()
            .Select(foo => new FeaturedLink(foo))
            .ToArray() ?? [];
    }
}
