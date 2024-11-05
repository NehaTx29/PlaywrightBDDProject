using NUnit.Framework;
using Microsoft.Playwright;
using Microsoft.Playwright.NUnit;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Events;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;

[Binding]
public class AmazonAddToCartS : BasePage
{
    private string productName;
    private string productPrice;
    private IPage productPage; // To hold the reference of the new product page

    [Given(@"I am on the Amazon homepage")]
    public async Task GivenIAmOnTheAmazonHomepage()
    {   
        // Navigate to Amazon.in 
        await Page.GotoAsync("https://www.amazon.in/");
        TestHooks.test.Log(Status.Pass, "Navigated to Amazon homepage.");
    }

    [When(@"I search for ""(.*)""")]
    public async Task WhenISearchFor(string searchItemName)
    {   
        // Enter keyword and click on search 
        await Page.FillAsync("//input[@id='twotabsearchtextbox']", searchItemName);
        await Page.ClickAsync("//input[@id='nav-search-submit-button']");
        TestHooks.test.Log(Status.Pass, $"Searched for product: {searchItemName}");
    }

    [When(@"I select the first product from the search results")]
    public async Task WhenISelectTheFirstProductFromTheSearchResults()
    {
        // Capture product name and price before clicking
        productName = await Page.InnerTextAsync("//div[@class='s-widget-container s-spacing-small s-widget-container-height-small celwidget slot=MAIN template=SEARCH_RESULTS widgetId=search-results_3']//div[@class='a-section a-spacing-none puis-padding-right-small s-title-instructions-style']//span[1]");
        productPrice = await Page.InnerTextAsync("div[class='s-widget-container s-spacing-small s-widget-container-height-small celwidget slot=MAIN template=SEARCH_RESULTS widgetId=search-results_3'] span[class='a-price-whole']");

        // Wait for the new page to open
        var productPageTask = Page.WaitForPopupAsync();
        await Page.ClickAsync("//div[@class='s-widget-container s-spacing-small s-widget-container-height-small celwidget slot=MAIN template=SEARCH_RESULTS widgetId=search-results_3']//div[@class='a-section a-spacing-none puis-padding-right-small s-title-instructions-style']//span[1]");
        
        // Store the new page reference
        productPage = await productPageTask; 
        await productPage.WaitForLoadStateAsync(); // Wait for the page to load

        TestHooks.test.Log(Status.Pass, $"Selected the first product: {productName}, Price: {productPrice}");
    }

    [When(@"I add the product to the cart")]
    public async Task WhenIAddTheProductToTheCart()
    {   
        // Add product to cart
        await productPage.ClickAsync("//div[@class='a-section a-spacing-none a-padding-none']//input[@id='add-to-cart-button']"); 
        
        // Wait for product to add before switching focus to main page
        await Task.Delay(1000);

        // Focus back to the main page
        await Page.BringToFrontAsync(); 
         TestHooks.test.Log(Status.Pass, "Added product to the cart.");
    }

    [Then(@"I should see the product in the cart")]
    public async Task ThenIShouldSeeTheProductInTheCart()
    {   
        // Click on Cart
        await Page.ClickAsync("//a[@id='nav-cart']"); 
        // Capture product name and price in the cart
        var cartProductName = await Page.InnerTextAsync("//span[@class='a-truncate-cut']");
        var cartProductPrice = await Page.InnerTextAsync("//span[@class='a-size-medium a-color-base sc-price sc-white-space-nowrap sc-product-price a-text-bold']"); 
        // Check if the cartProductName ends with "..." and remove it if so
        Console.WriteLine(cartProductName);
        if(cartProductName.EndsWith("…"))
        {
            cartProductName = cartProductName.Substring(0, cartProductName.Length - 3); // Removes the last three characters
        }
        if(cartProductPrice.EndsWith(".00"))
        {
            cartProductPrice = cartProductPrice.Substring(0, cartProductPrice.Length - 3);
        }

        // Assert statements to validate product and price
        Assert.IsTrue(productName.Trim().Contains(cartProductName.Trim()), $"Product name in cart '{cartProductName}' does not match the expected name '{productName}'.");
        Assert.AreEqual(productPrice.Trim(), cartProductPrice.Trim(), $"Product price in cart '{cartProductPrice}' does not match the expected price '{productPrice}'.");
        // Console.WriteLine($"Cart Product Name: {cartProductName}");
        // Console.WriteLine($"Cart Product Price: {cartProductPrice}");
        TestHooks.test.Log(Status.Pass, $"Validated product in cart: {cartProductName}, Price: {cartProductPrice}");
    }
}
