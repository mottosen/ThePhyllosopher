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

        public string? BodyText => node.BodyText?.ToHtmlString() ?? null;
    }
}
