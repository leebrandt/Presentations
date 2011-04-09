namespace SFT.Core.Services.Authentication
{
    public interface AuthenticationService
    {
        void SignIn(string loginId);
        bool Authenticate(string username, string password);
        void SetRole(string username);
    }
}