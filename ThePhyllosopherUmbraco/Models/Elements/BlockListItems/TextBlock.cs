using Umbraco.Cms.Core.Strings;
using Umbraco.Cms.Web.Common.PublishedModels;

namespace ThePhyllosopherUmbraco.Models.Elements
{
    public class TextBlock
    {
        BlockListItemTextBlock node;

        public TextBlock(BlockListItemTextBlock node)
        {
            this.node = node;
        }

        public IHtmlEncodedString? BodyText => node.BodyText;
    }
}
