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
}
