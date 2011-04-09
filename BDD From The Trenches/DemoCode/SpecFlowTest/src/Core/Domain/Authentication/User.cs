namespace SFT.Core.Domain.Authentication
{
    public class User : PersistentObject
    {
        public virtual string Username { get; set; }
        public virtual string Password { get; set; }
    }
}