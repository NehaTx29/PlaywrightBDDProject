using Microsoft.Playwright;

public class TxPage : BasePage
{
    public ILocator SignInButton => Page.Locator("#dropdown-autoclose-true");
    public ILocator LoginButton => Page.Locator("//div[contains(@class,'show dropdown')]//a");
    public ILocator LoginPage => Page.Locator("[name='Login']");
    public ILocator Email => Page.Locator("[name='email']");
    public ILocator Password => Page.Locator("[name='password']");
    public ILocator Login => Page.Locator("[type='submit']");
    public ILocator HomePage => Page.Locator(".fa-cart-plus");
    public ILocator AllDropDown => Page.Locator("//div[@title='All Category']/button[@id='dropdown-basic']");
    public ILocator AllDropDownOptions => Page.Locator("//div[contains(@class,'dropdown-menu show')]");
    public ILocator AllDropDownOptionsCount => Page.Locator("//div[contains(@class,'dropdown-menu show')]//a");
    public ILocator FirstProductNameSelector => Page.Locator("//h6[contains(text(),'Jager-Smith PB-1000 Combo & Featherlite 2 Shuttle ')]");
    public ILocator AddToWishlistButton => Page.Locator("//button[normalize-space()='Add To Wishlist']");
    public ILocator YourWishlistButton => Page.Locator("//a[normalize-space()='Your Wishlist']");
    public ILocator WishlistProductName => Page.Locator("//span[@id='spWishlistTitle']");
    public ILocator YourOrdersButton => Page.Locator("//a[normalize-space()='Your Orders']");
    
    public const string OrdersPageUrl = "http://3.94.149.173:9090/orders";

    public async Task clickLogin()
    {
        await SignInButton.ClickAsync();
        await LoginButton.ClickAsync();
    }

    public async Task LoginToWebsite(string email, string pass)
    {
        await Email.FillAsync(email);
        await Password.FillAsync(pass);
        await Login.ClickAsync();
        await HomePage.WaitForAsync(new LocatorWaitForOptions { State = WaitForSelectorState.Visible });
    }

    public async Task<string> GetFirstProductName()
    {
        return await FirstProductNameSelector.TextContentAsync();
    }

    public async Task ClickYourWishlist()
    {
        await SignInButton.ClickAsync();
        await YourWishlistButton.ClickAsync();
    }

    public async Task<string> GetWishlistProductName()
    {
        return await WishlistProductName.TextContentAsync();
    }

    public async Task ClickYourOrders()
    {
        await SignInButton.ClickAsync();
        await YourOrdersButton.ClickAsync();
    }

}
