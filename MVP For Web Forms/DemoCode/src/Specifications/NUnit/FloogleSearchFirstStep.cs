using NUnit.Framework;

namespace BddDemo.Specifications.NUnit
{
    [TestFixture]
    public class When_loading_the_foogle_search_page_1
    {
        [SetUp]
        public void Context()
        {
            // Some context in which the user would be doing something
            Action();
        }

        public void Action()
        {
            // some thing that the user does in that context
        }

        [Test]
        public void It_should_load_the_empty_floogle_search_form()
        {
            // an observation about what the system should do in this instance
        }
    }
}