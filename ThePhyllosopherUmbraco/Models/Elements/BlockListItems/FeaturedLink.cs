using Umbraco.Cms.Core.Models;
using Umbraco.Cms.Web.Common.PublishedModels;

namespace ThePhyllosopherUmbraco.Models.Elements
{
    public class FeaturedLink
    {
        BlockListItemFeaturedLink _block;

        public FeaturedLink(BlockListItemFeaturedLink block)
        {
            _block = block;
        }

        public string LinkTitle => string.IsNullOrWhiteSpace(_block.LinkTitle) ? "" : _block.LinkTitle;
        public Link? Link => _block.Link;
        public MediaWithCrops? LinkImage => _block.LinkImage;
        public string LinkDescription => string.IsNullOrWhiteSpace(_block.LinkDescription) ? "" : _block.LinkDescription;
    }
}
