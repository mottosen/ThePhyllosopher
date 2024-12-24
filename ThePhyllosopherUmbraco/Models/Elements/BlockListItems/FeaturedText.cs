using Umbraco.Cms.Web.Common.PublishedModels;

namespace ThePhyllosopherUmbraco.Models.Elements
{
    public class FeaturedText
    {
        BlockListItemFeaturedText _block;

        public FeaturedText(BlockListItemFeaturedText block)
        {
            this._block = block;
        }

        public string? Text => _block.Text;
    }
}
