using Microsoft.Playwright;
using System.Threading.Tasks;

public abstract class BasePage 
{
    protected IPage Page => TestHooks.Page;
    // protected IPage Page { get; private set; }

    // protected BasePage(IPage page){
    //     Page = page;
    // }

    public async Task NavigateToUrl(String url) 
    {
        await Page.GotoAsync(url);
    }
}
