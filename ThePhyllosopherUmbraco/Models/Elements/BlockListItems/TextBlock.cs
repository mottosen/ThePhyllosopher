using Umbraco.Cms.Core.Strings;
using Umbraco.Cms.Web.Common.PublishedModels;

namespace ThePhyllosopherUmbraco.Models.Elements
{
    public class TextBlock
    {
        BlockListItemTextBlock _block;

        public TextBlock(BlockListItemTextBlock block)
        {
            this._block = block;
        }

        public IHtmlEncodedString? BodyText => _block.BodyText;
    }
}
