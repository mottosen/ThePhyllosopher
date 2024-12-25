using Umbraco.Cms.Core.Strings;
using Umbraco.Cms.Web.Common.PublishedModels;

namespace ThePhyllosopherUmbraco.Models.Elements
{
    public class CenterText
    {
        BlockListItemCenterText _block;

        public CenterText(BlockListItemCenterText block)
        {
            this._block = block;
        }

        public string Title => string.IsNullOrWhiteSpace(_block.BlockTitle) ? "" : _block.BlockTitle;
        public IHtmlEncodedString? BodyText => _block.BodyText;
    }
}
