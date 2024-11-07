using TechTalk.SpecFlow;

[Binding]
public class TxHomePage : BasePage
{
    private TxPage txPage;

    public TxHomePage() {
        txPage = new TxPage();
    }
     
    [Given(@"I navigate to Tx website ""(.*)""")]
    public async Task INavigateToTxWebsite(String url)
    {
        await Page.GotoAsync(url);
    }

    [When(@"I click on Login Button")]
    public async Task IClickOnLoginButton()
    {
        await txPage.clickLogin();
    }

    [Then(@"I should see the Login Page")]
    public async Task IShouldSeeLoginPage()
    {
        Assert.IsTrue(await txPage.LoginPage.IsVisibleAsync(), "Login page should be visible");
    }

    [When(@"I login using email ""(.*)"" and password ""(.*)""")]
    public async Task ILoginUsingEmailAndPassword(String email, String pass)
    {
        await txPage.LoginToWebsite(email, pass);
    }

    [Then(@"I should see Homepage")]
    public async Task IShouldSeeHomePage()
    {
        Assert.IsTrue(await txPage.HomePage.IsVisibleAsync(), "Home page should be visible");
    }

    [When(@"I scroll down & click on All dropdown")]
    public async Task IScrollDownAndClickOnAllDropDown()
    {
        await txPage.AllDropDown.ScrollIntoViewIfNeededAsync();
        await txPage.AllDropDown.ClickAsync();
        await txPage.AllDropDownOptions.IsVisibleAsync();
    }

    [Then(@"I should see all the products in the dropdown")]
    public async Task IShouldSeeAllProductsInDropDown()
    {
        Assert.IsTrue(await txPage.AllDropDownOptions.IsVisibleAsync(), "All Drop Down Options Should be displayed");
        Assert.That(await txPage.AllDropDownOptionsCount.CountAsync(), Is.GreaterThan(1), "Drop Down List should show count more than 1");
    }
}
