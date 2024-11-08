using TechTalk.SpecFlow;

namespace PlaywrightTests.StepDefinitions
{
    [Binding]
    public class TxOrderSteps : BasePage
    {
        private TxPage txPage;

        public TxOrderSteps()
        {
            txPage = new TxPage();
        }

        [Given(@"I navigate to the AI Engine url ""(.*)""")]
        public async Task GivenINavigateToTheAIEngineUrl(string url)
        {
            await Page.GotoAsync(url);
        }

        [Then(@"I click on Login option")]
        public async Task ThenIClickOnLoginOption()
        {
            await txPage.clickLogin();
        }

        [When(@"I enter email ""(.*)"" and password ""(.*)"" on AI engine")]
        public async Task WhenIEnterEmailAndPasswordOnAIEngine(string email, string password)
        {
            await txPage.LoginToWebsite(email, password);
        }

        [Then(@"I should see the homepage after successful login")]
        public async Task ThenIShouldSeeTheHomepageAfterSuccessfulLogin()
        {
            Assert.IsTrue(await txPage.HomePage.IsVisibleAsync(), "Homepage is not visible after login.");
        }

        [When(@"I click on Your Orders option from Account and Lists dropdown")]
        public async Task WhenIClickOnYourOrdersOptionFromAccountAndListsDropdown()
        {
            await txPage.ClickYourOrders();
        }

        [Then(@"I should see the orders page")]
        public async Task ThenIShouldSeeTheOrdersPage()
        {   
            var currentUrl = Page.Url;
            Assert.AreEqual(currentUrl, TxPage.OrdersPageUrl,  $"Expected URL '{TxPage.OrdersPageUrl}' does not match the current URL '{currentUrl}'.");
        }
    }
}
