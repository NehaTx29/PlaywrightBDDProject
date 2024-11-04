using Microsoft.Playwright;
using Microsoft.Playwright.NUnit;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Events;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;

[Binding]
public class SampleGoogleSearchS : BasePage
{
    private GooglePage googlePage;

    public SampleGoogleSearchS() {
        googlePage = new GooglePage();
    }
     
    [Given(@"I perform Google Search")]
    public async Task IperformGoogleSearch()
    {
        await Page.GotoAsync("https://www.google.com");
        await googlePage.PerformSearch("Neha Test");
        TestHooks.test.Pass("tested");
    }
}
