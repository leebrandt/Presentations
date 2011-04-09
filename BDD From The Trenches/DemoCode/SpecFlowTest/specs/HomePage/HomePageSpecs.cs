using System.Web.Mvc;
using Machine.Specifications;
using MvcContrib.TestHelper;
using SFT.Web.UI.Controllers;

namespace SFT.Specifications.HomePage
{
    [Subject("10 - Home Page")]
    public class When_a_user_wishes_to_view_the_website : With_the_main_site_routes_registered
    {
        It should_navigate_to_the_home_page = () =>
            "~/".ShouldMapTo<HomeController>(ctrl => ctrl.Index());
    }

    public class When_navigating_to_the_home_page
    {
        Establish context = () =>
            {
                _controller = new HomeController();
            };

        Because of = () => _result = _controller.Index();

        It should_load_the_home_page = () =>
            _result.AssertViewRendered().ForView("Index");

        static HomeController _controller;
        static ActionResult _result;
    }
}