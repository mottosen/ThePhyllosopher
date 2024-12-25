using Umbraco.Cms.Core.Models;
using Umbraco.Cms.Web.Common.PublishedModels;

namespace ThePhyllosopherUmbraco.Models.Pages
{
    public class Employee
    {
        PageEmployee node;

        public Employee(PageEmployee node)
        {
            this.node = node;
        }

        public PageEmployee Page => node;
        public string Name => string.IsNullOrWhiteSpace(node.EmployeeName) ? node.Name : node.EmployeeName;
        public string ShortBiography => string.IsNullOrWhiteSpace(node.ShortDescription) ? "" : node.ShortDescription;
        public MediaWithCrops? Image => node.EmployeeImage;
    }
}
