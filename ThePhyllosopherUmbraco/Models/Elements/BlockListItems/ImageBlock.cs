using Umbraco.Cms.Core.Models;
using Umbraco.Cms.Web.Common.PublishedModels;

namespace ThePhyllosopherUmbraco.Models.Elements
{
    public class ImageBlock
    {
        BlockListItemImageBlock _block;

        public ImageBlock(BlockListItemImageBlock block)
        {
            this._block = block;
        }

        public MediaWithCrops? Image => _block.Image;
        public string? Caption => string.IsNullOrWhiteSpace(_block.Caption) ? null : _block.Caption;
    }
}
