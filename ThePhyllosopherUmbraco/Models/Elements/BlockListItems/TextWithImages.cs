using Umbraco.Cms.Core.Models;
using Umbraco.Cms.Core.Strings;
using Umbraco.Cms.Web.Common.PublishedModels;

namespace ThePhyllosopherUmbraco.Models.Elements
{
    public class TextWithImages
    {
        BlockListItemTextWithImages _block;

        public TextWithImages(BlockListItemTextWithImages block)
        {
            _block = block;
        }

        public string Title => string.IsNullOrWhiteSpace(_block.BlockTitle) ? "" : _block.BlockTitle;
        public IHtmlEncodedString? Text => _block.BlockText;
        public IEnumerable<MediaWithCrops> Images => _block.Images ?? [];
    }
}
