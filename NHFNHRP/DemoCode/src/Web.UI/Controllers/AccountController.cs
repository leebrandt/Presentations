using System.Web.Mvc;
using System.Web.Security;
using Core.Data;
using Web.UI.Models;

namespace Web.UI.Controllers
{
    public class AccountController : Controller
    {
        readonly UserRepository _userRepository;

        public AccountController(UserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public ActionResult Login()
        {
            return View("Login", new LoginModel());
        }

        [HttpPost]
        public ActionResult Login(LoginModel loginModel)
        {
            var user = _userRepository.GetByUsername(loginModel.Username);
            if (user != null && user.Password == loginModel.Password)
                FormsAuthentication.RedirectFromLoginPage(loginModel.Username, false);

            ModelState.AddModelError("", "The login attempt was unsuccessful.");
            return View("Login", new LoginModel());
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }
    }
}