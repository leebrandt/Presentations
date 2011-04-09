using System.Web.Mvc;
using Machine.Specifications;
using MvcContrib.TestHelper;
using SFT.Web.UI.Controllers;

namespace SFT.Specifications.AboutUs
{
    [Subject("20 - About Us Page")]
    public class When_a_user_wish_to_find_out_about_nahp : With_the_main_site_routes_registered
    {
        It should_navigate_to_the_about_us_page = () =>
            "~/home/about".ShouldMapTo<HomeController>(ctrl => ctrl.About());
    }

    [Subject("20 - About Us Page")]
    public class When_navigating_to_the_about_us_page
    {
        Establish context = () =>
            {
                _controller = new HomeController();
            };

        Because of = () => _result = _controller.About();

        It should_load_the_about_us_page = () =>
            _result.AssertViewRendered().ForView("About");

        static HomeController _controller;
        static ActionResult _result;
    }
}