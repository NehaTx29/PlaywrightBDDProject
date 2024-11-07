using Microsoft.Playwright;
using System.Threading.Tasks;

public class AmazonPage 
{
    private readonly IPage _page;

    // Homepage Locators
    private const string SearchBoxSelector = "//input[@id='twotabsearchtextbox']";
    private const string SearchButtonSelector = "//input[@id='nav-search-submit-button']";

    // Search Results Page Locators
    private const string FirstProductNameSelector = "//div[contains(@class, 'slot=MAIN template=SEARCH_RESULTS widgetId=search-results_3')]//div[contains(@class, 'puis-padding-right-small s-title-instructions-style')]//span[1]";
    private const string FirstProductPriceSelector = "div[class='s-widget-container s-spacing-small s-widget-container-height-small celwidget slot=MAIN template=SEARCH_RESULTS widgetId=search-results_3'] span[class='a-price-whole']";
    private const string FirstProductSelector = "//div[contains(@class, 'slot=MAIN template=SEARCH_RESULTS widgetId=search-results_3')]//div[contains(@class, 'puis-padding-right-small s-title-instructions-style')]//span[1]";

    // Product Page Locator
    private const string AddToCartButtonSelector = "//div[@class='a-section a-spacing-none a-padding-none']//input[@id='add-to-cart-button']";

    // Cart Page Locators
    private const string CartProductNameSelector = "//span[@class='a-truncate-cut']";
    private const string CartProductPriceSelector = "span[class='a-truncate sc-grid-item-product-title a-size-base-plus'] span[class='a-truncate-cut']";
    private const string CartButtonSelector = "//a[@id='nav-cart']";

    public AmazonPage(IPage page)
    {
        _page = page;
    }

    // Homepage Actions
    public async Task NavigateToHomePage()
    {
        await _page.GotoAsync(Config.AmazonUrl);
    }

    public async Task SearchForProduct(string searchItemName)
    {
        await _page.FillAsync(SearchBoxSelector, searchItemName);
        await _page.ClickAsync(SearchButtonSelector);
    }

    // Search Results Actions
    public async Task<string> GetFirstProductName()
    {
        return await _page.InnerTextAsync(FirstProductNameSelector);
    }

    public async Task<string> GetFirstProductPrice()
    {
        return await _page.InnerTextAsync(FirstProductPriceSelector);
    }

    public async Task<IPage> SelectFirstProduct()
    {
        var productPageTask = _page.WaitForPopupAsync();
        await _page.ClickAsync(FirstProductSelector);
        var productPage = await productPageTask;
        await productPage.WaitForLoadStateAsync();
        return productPage;
    }

    // Product Page Actions
    public async Task AddProductToCart(IPage productPage)
    {
        await productPage.ClickAsync(AddToCartButtonSelector);
    }

    // Cart Actions
    public async Task NavigateToCart()
    {
        await _page.ClickAsync(CartButtonSelector);
    }

    public async Task<string> GetCartProductName()
    {
        var cartProductName = await _page.InnerTextAsync(CartProductNameSelector);
        if (cartProductName.EndsWith("…"))
        {
            cartProductName = cartProductName.Substring(0, cartProductName.Length - 3);
        }
        return cartProductName;
    }

    public async Task<string> GetCartProductPrice()
    {
        var cartProductPrice = await _page.InnerTextAsync(CartProductPriceSelector);
        if (cartProductPrice.EndsWith(".00"))
        {
            cartProductPrice = cartProductPrice.Substring(0, cartProductPrice.Length - 3);
        }
        return cartProductPrice;
    }
}
