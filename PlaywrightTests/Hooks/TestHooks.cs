using Microsoft.Playwright;
using TechTalk.SpecFlow;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;

[Binding]
public class TestHooks
{
    public static IPage Page { get; private set; }
    public static ExtentReports extent;
    public static ExtentTest test;
    private readonly ScenarioContext _scenarioContext;

    public TestHooks(ScenarioContext scenarioContext)
    {
        _scenarioContext = scenarioContext;
    }

    [BeforeTestRun]
    public static void SetupReport()
    {
        var outputDirectory = Path.Combine(Directory.GetCurrentDirectory(), "..", "..", "..", "test-output");
        var reportPath = Path.Combine(outputDirectory, "ExtentReport.html");
        var htmlReporter = new ExtentSparkReporter(reportPath);
        extent = new ExtentReports();
        extent.AttachReporter(htmlReporter);
    }

    [BeforeScenario]
    public async Task Setup() 
    {
        var playwright = await Playwright.CreateAsync();
        var browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions { Headless = false });
        Page = await browser.NewPageAsync();
        test = extent.CreateTest(_scenarioContext.ScenarioInfo.Title);
    }

    [AfterScenario]
    public async Task TearDown()
    {
        if(_scenarioContext.TestError != null) 
        {
            await takeScreenshot();
        }
        await Page.CloseAsync();
        extent.Flush();
    }

    [AfterTestRun]
    public static void TearDownReport()
    {
        extent.Flush();
    }

    private async Task takeScreenshot() 
    {
        var outputDirectory = Path.Combine(Directory.GetCurrentDirectory(), "..", "..", "..", "test-output");
        var screenshotPath = Path.Combine(outputDirectory, $"{_scenarioContext.ScenarioInfo.Title}_screenshot.png");
        var screenshot = await Page.ScreenshotAsync(new()
            {
                Path = screenshotPath,
                FullPage = true
            });
        test.Fail("Screenshot on failure:").AddScreenCaptureFromPath(screenshotPath);
    }
}
