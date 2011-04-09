using System.Web.Security;
using SFT.Core.Data;

namespace SFT.Core.Services.Authentication
{
    public class WebAuthenticationService : AuthenticationService
    {
        readonly UserRepository _userRepository;

        public WebAuthenticationService(UserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public void SignIn(string loginId)
        {
            FormsAuthentication.SetAuthCookie(loginId, false);
        }

        public bool Authenticate(string username, string password)
        {
            var user = _userRepository.GetByUsername(username);
            if (user == null) return false;
            return user.Password == password;
        }

        public void SetRole(string username)
        {
        }
    }
}