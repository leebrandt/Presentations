using System.Web.Routing;
using Machine.Specifications;
using SFT.Web.UI;

namespace SFT.Specifications
{
    public class With_the_main_site_routes_registered
    {
        Establish context = () =>
        {
            RouteTable.Routes.Clear();
            MvcApplication.RegisterRoutes(RouteTable.Routes);
        };
    }
}