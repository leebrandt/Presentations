using System.Web.Mvc;
using SFT.Core.Domain.Authentication;
using SFT.Core.Services.Authentication;

namespace SFT.Web.UI.Controllers
{
    public class AdminController : Controller
    {
        readonly AuthenticationService _authenticationService;

        public AdminController(AuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        [Authorize(Roles = "Administrators")]
        public ActionResult Index()
        {
            return View("Index");
        }

        public ActionResult Login()
        {
            return View("Login");
        }

        [HttpPost]
        public ActionResult Login(User user)
        {
            _authenticationService.Authenticate(user.Username, user.Password);

            return null;
        }
    }
}
