using Umbraco.Cms.Core.Models.PublishedContent;
using Umbraco.Cms.Web.Common.PublishedModels;

namespace ThePhyllosopherUmbraco.Utility
{
    public class UmbracoUtility
    {
        static public PageHome GetHomePage(IPublishedContent node) => node.Root<PageHome>();
    }
}
