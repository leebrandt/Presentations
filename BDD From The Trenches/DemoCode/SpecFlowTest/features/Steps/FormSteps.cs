using TechTalk.SpecFlow;
using WatiN.Core;

namespace SFT.Features.Steps
{
    [Binding]
    public class FormSteps
    {
        [Given(@"I have entered '(.*)' in the '(.*)' textbox")]
        public void GivenIHaveEnteredValueInTheIdTextbox(string value, string id)
        {
            WebBrowser.Current.TextField(Find.ById(id)).TypeText(value);
        }

        [When(@"I click the '(.*)' button")]
        public void WhenIClickTheButton(string value)
        {
            WebBrowser.Current.Button(Find.ByValue(value)).Click();
        }
    }
}