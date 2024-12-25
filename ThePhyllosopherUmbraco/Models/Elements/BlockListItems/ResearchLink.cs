using Umbraco.Cms.Core.Models;
using Umbraco.Cms.Web.Common.PublishedModels;

namespace ThePhyllosopherUmbraco.Models.Elements
{
    public class ResearchLink
    {
        BlockListItemResearchLink _block;

        public ResearchLink(BlockListItemResearchLink block)
        {
            _block = block;
        }

        public string LinkTitle => string.IsNullOrWhiteSpace(_block.LinkTitle) ? "" : _block.LinkTitle;
        public Link? Link => _block.Link;
        public MediaWithCrops? LinkImage => _block.LinkImage;
        public string LinkDescription => string.IsNullOrWhiteSpace(_block.LinkDescription) ? "" : _block.LinkDescription;
        public string LinkType => string.IsNullOrWhiteSpace(_block.LinkType) ? "" : _block.LinkType;
    }
}
