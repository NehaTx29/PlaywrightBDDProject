using Microsoft.Playwright;

public class GooglePage : BasePage
{
    public ILocator SearchBox => Page.Locator("[title=Search]");
    public ILocator SearchButton => Page.Locator("[name=btnK]");

    public async Task PerformSearch(string query)
    {
        await SearchBox.FillAsync(query);
        await SearchBox.PressAsync("Enter");
    }
}

