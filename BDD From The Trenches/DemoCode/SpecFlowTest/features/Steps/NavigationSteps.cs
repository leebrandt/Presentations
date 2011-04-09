using NUnit.Framework;
using TechTalk.SpecFlow;
using WatiN.Core;

namespace SFT.Features.Steps
{
    [Binding]
    public class NavigationSteps
    {
        [When(@"I navigate to '(.*)'")]
        public void WhenINavigateTo(string relativeUrl)
        {
            WebBrowser.NavigateTo(relativeUrl);
        }

        [Given(@"I am on the '(.*)' page")]
        public void GivenIAmOnThePage(string relativeUrl)
        {
            WebBrowser.NavigateTo(relativeUrl);
        }

        [When(@"I click the '(.*)' link")]
        public void WhenIClickTheLink(string linkText)
        {
            WebBrowser.Current.Link(Find.ByText(linkText)).Click();
        }

        [Then(@"the '(.*)' page should be displayed")]
        public void ThenThePageShouldBeDisplayed(string pageTitle)
        {
            Assert.That(WebBrowser.Current.Title.EndsWith(pageTitle), 
                "Expected page title to end with {0}, but was {1}", pageTitle, WebBrowser.Current.Title);
        }

        [When(@"I click the '(.*)' image")]
        public void WhenIClickTheImageWithId(string id)
        {
            WebBrowser.Current.Link(Find.ById(id)).Click();
        }

        [Then(@"I should see '(.*)' on the page")]
        public void ThenIShouldSeeMessageOnThePage(string message)
        {
            Assert.That(WebBrowser.Current.Text.Contains(message), 
                "Expected to find the text '{0}' somewhere on the page, but did not.", message);
        }

        [Then(@"the '(.*)' link should be visible")]
        public void ThenTheLinkShouldBeVisible(string linkText)
        {
            Assert.That(WebBrowser.Current.Link(Find.ByText(linkText)).Exists, 
                "Expected to find a link with the text '{0}' somewhere on the page, but did not.", linkText);
        }

        [Given(@"I am not logged in to the site")]
        public void GivenIAmNotLoggedInToTheSite() 
        {
            WhenINavigateTo("/home");
            var logoutLink = WebBrowser.Current.Link(Find.ByText("Log Out"));
            if(logoutLink.Exists)
                logoutLink.Click();
        }

        [BeforeScenario]
        public void SetUpScenario()
        {

        }

        [AfterScenario]
        public void CleanUp()
        {
            WebBrowser.Current.Close();
        }
    }
}