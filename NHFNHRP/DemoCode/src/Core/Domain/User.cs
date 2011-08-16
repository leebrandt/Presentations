using System;

namespace Core.Domain
{
    public class User
    {
        public virtual Guid ID { get; set; }
        public virtual string Username { get; set; }
        public virtual string Password { get; set; }
    }
}