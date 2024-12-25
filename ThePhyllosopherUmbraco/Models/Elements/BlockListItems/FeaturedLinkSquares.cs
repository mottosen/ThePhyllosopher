using Umbraco.Cms.Web.Common.PublishedModels;

namespace ThePhyllosopherUmbraco.Models.Elements
{
    public class FeaturedSquares
    {
        BlockListItemFeaturedSquares _block;

        public FeaturedSquares(BlockListItemFeaturedSquares block)
        {
            _block = block;
        }

        public string BlockSubtitle => string.IsNullOrWhiteSpace(_block.BlockSubtitle) ? "" : _block.BlockSubtitle;
		public string BlockTitle => string.IsNullOrWhiteSpace(_block.BlockTitle) ? "" : _block.BlockTitle;
        public IEnumerable<ResearchLink> Links => _block.FeaturedLinks?.Select(link => new ResearchLink(link.Content as BlockListItemResearchLink)) ?? [];
	}
}
