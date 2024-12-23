using Umbraco.Cms.Core.Models;
using Umbraco.Cms.Web.Common.PublishedModels;

namespace ThePhyllosopherUmbraco.Models.Elements
{
    public class ImageBlock
    {
        BlockListItemImageBlock node;

        public ImageBlock(BlockListItemImageBlock node)
        {
            this.node = node;
        }

        public MediaWithCrops? Image => node.Image;
        public string? Caption => string.IsNullOrWhiteSpace(node.Caption) ? null : node.Caption;
    }
}
