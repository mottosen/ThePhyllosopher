using Umbraco.Cms.Web.Common.PublishedModels;

namespace ThePhyllosopherUmbraco.Models.Pages
{
    public class Contact : PageBase
    {
        PageContact _node;

        public Contact(PageContact node) : base(node)
        {
            _node = node;
        }

        public string GoogleEmbedLink => string.IsNullOrWhiteSpace(_node.GoogleMapsLink) ? "" : _node.GoogleMapsLink;
        public string Address => string.IsNullOrWhiteSpace(_node.Address) ? "" : _node.Address;
        public string Phone => string.IsNullOrWhiteSpace(_node.PhoneNumber) ? "" : _node.PhoneNumber;
        public string Email => string.IsNullOrWhiteSpace(_node.Email) ? "" : _node.Email;
    }
}
