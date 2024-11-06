using NUnit.Framework;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using AventStack.ExtentReports;
using Microsoft.Playwright;

[Binding]
public class AmazonAddToCartS : BasePage
{
    private readonly AmazonPage _amazonPage;
    private string productName;
    private string productPrice;
    private IPage productPage;

    public AmazonAddToCartS()
    {
        _amazonPage = new AmazonPage(Page);
    }

    [Given(@"I am on the Amazon homepage")]
    public async Task GivenIAmOnTheAmazonHomepage()
    {
        await _amazonPage.NavigateToHomePage();
        TestHooks.test.Log(Status.Pass, "Navigated to Amazon homepage.");
    }

    [When(@"I search for ""(.*)""")]
    public async Task WhenISearchFor(string searchItemName)
    {
        await _amazonPage.SearchForProduct(searchItemName);
        TestHooks.test.Log(Status.Pass, $"Searched for product: {searchItemName}");
    }

    [When(@"I select the first product from the search results")]
    public async Task WhenISelectTheFirstProductFromTheSearchResults()
    {
        productName = await _amazonPage.GetFirstProductName();
        productPrice = await _amazonPage.GetFirstProductPrice();
        productPage = await _amazonPage.SelectFirstProduct();

        TestHooks.test.Log(Status.Pass, $"Selected the first product: {productName}, Price: {productPrice}");
    }

    [When(@"I add the product to the cart")]
    public async Task WhenIAddTheProductToTheCart()
    {
        await _amazonPage.AddProductToCart(productPage);
        await Task.Delay(1000);                              // Wait for product to add to the cart
        await Page.BringToFrontAsync();                      // Focus back to the main page

        TestHooks.test.Log(Status.Pass, "Added product to the cart.");
    }

    [Then(@"I should see the product in the cart")]
    public async Task ThenIShouldSeeTheProductInTheCart()
    {
        await _amazonPage.NavigateToCart();

        var cartProductName = await _amazonPage.GetCartProductName();
        var cartProductPrice = await _amazonPage.GetCartProductPrice();

        Assert.IsTrue(productName.Trim().Contains(cartProductName.Trim()), $"Product name in cart '{cartProductName}' does not match the expected name '{productName}'.");
        Assert.AreEqual(productPrice.Trim(), cartProductPrice.Trim(), $"Product price in cart '{cartProductPrice}' does not match the expected price '{productPrice}'.");
        
        TestHooks.test.Log(Status.Pass, $"Validated product in cart: {cartProductName}, Price: {cartProductPrice}");
    }
}
