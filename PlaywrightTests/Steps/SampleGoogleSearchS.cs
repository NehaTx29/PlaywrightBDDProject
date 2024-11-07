using TechTalk.SpecFlow;

[Binding]
public class SampleGoogleSearchS : BasePage
{
    private GooglePage googlePage;

    public SampleGoogleSearchS() {
        googlePage = new GooglePage();
    }
     
    [Given(@"I perform Google Search ""(.*)""")]
    public async Task IperformGoogleSearch(String searchText)
    {
        await Page.GotoAsync(Config.GoogleUrl);
        await googlePage.PerformSearch(searchText);
        TestHooks.test.Pass("tested");
    }
}
