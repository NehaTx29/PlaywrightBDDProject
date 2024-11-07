using TechTalk.SpecFlow;

[Binding]
public class TxAddToWishlistS : BasePage
{
    private TxPage txPage;
    private string productName;

    public TxAddToWishlistS()
    {
        txPage = new TxPage();
    }

    [Given(@"I navigate to Tx website ""(.*)"" Wishlist section")]
    public async Task INavigateToTxWebsiteWishlistSection(String url)
    {
        await Page.GotoAsync(url);
    }

    [When(@"I click on Login button Wishlist section")]
    public async Task IClickOnLoginButtonWishlistSection()
    {
        await txPage.clickLogin();
    }

    [Then(@"I should see the Login Page Wishlist section")]
    public async Task IShouldSeeLoginPageWishlistSection()
    {
        Assert.IsTrue(await txPage.LoginPage.IsVisibleAsync(), "Login page should be visible");
    }

    [When(@"I login using email ""(.*)"" and password ""(.*)"" Wishlist section")]
    public async Task ILoginUsingEmailAndPasswordWishlistSection(String email, String pass)
    {
        await txPage.LoginToWebsite(email, pass);
    }

    [Then(@"I should see Homepage Wishlist section")]
    public async Task IShouldSeeHomePageWishlistSection()
    {
        Assert.IsTrue(await txPage.HomePage.IsVisibleAsync(), "Home page should be visible");
    }

    [When(@"I click on first product")]
    public async Task IClickOnFirstProduct()
    {
        productName = await txPage.GetFirstProductName();
        await txPage.FirstProductNameSelector.ClickAsync();       
    }

    [When(@"I scroll and click on Add To Wishlist")]
    public async Task IScrollAndClickOnAddToWishlist()
    {
        await txPage.AddToWishlistButton.ScrollIntoViewIfNeededAsync();
        await txPage.AddToWishlistButton.ClickAsync();
    }

    [When(@"I click on Your Wishlist option from Account and Lists dropdown")]
    public async Task IClickOnYourWishlistOptionFromAccountAndListsDropdown()
    {
        await txPage.ClickYourWishlist();
    }

    [Then(@"I should see the product in wishlist page")]
    public async Task ThenIShouldSeeTheProductInWishlistPage()
    {
        var wishlistProductName = await txPage.GetWishlistProductName();

        Assert.IsTrue(productName.Contains(wishlistProductName), $"Product name in wishlist : {wishlistProductName} does not match with the expected name : {productName}");
    }
}