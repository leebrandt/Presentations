using SFT.Core.Data;
using SFT.Core.Domain.Authentication;
using StructureMap;
using TechTalk.SpecFlow;

namespace SFT.Features.Steps
{
    [Binding]
    public class AccountLogin
    {
        [Given(@"that a user with a username of '(.*)' and a password of '(.*)' exists")]
        public void GivenThatASpecifiedUserExists(string username, string password)
        {
            var repo = ObjectFactory.GetInstance<Repository>();
            var user = new User { Username = username, Password = password };
            repo.Save(user);
        }
    }
}