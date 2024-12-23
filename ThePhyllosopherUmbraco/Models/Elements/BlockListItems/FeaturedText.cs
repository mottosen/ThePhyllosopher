using Umbraco.Cms.Web.Common.PublishedModels;

namespace ThePhyllosopherUmbraco.Models.Elements
{
    public class FeaturedText
    {
        BlockListItemFeaturedText node;

        public FeaturedText(BlockListItemFeaturedText node)
        {
            this.node = node;
        }

        public string? Text => node.Text;
    }
}
