using System.Web.Mvc;
using SFT.Core.Services.Authentication;
using SFT.Web.UI.Models;

namespace SFT.Web.UI.Controllers
{
    public class AccountController : Controller
    {
        readonly AuthenticationService _authenticationService;

        public AccountController(AuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        public ActionResult Login()
        {
            return View("Login", new LoginModel());
        }

        [HttpPost]
        public ActionResult Login(LoginModel loginModel)
        {
            if (!_authenticationService.Authenticate(loginModel.Username, loginModel.Password))
            {
                ModelState.AddModelError("login", "Username or password appears to be invalid.");
                return View("Login");
            }
            _authenticationService.SignIn(loginModel.Username);
            return RedirectToAction("Index", "Home");
        }
    }
}
