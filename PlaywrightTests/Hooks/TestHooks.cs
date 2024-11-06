
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
        var reportPath = Path.Combine(Config.TestOutputFolder, "ExtentReport.html");
        var htmlReporter = new ExtentSparkReporter(reportPath);
        extent = new ExtentReports();
        extent.AttachReporter(htmlReporter);
    }

    [BeforeScenario]
    public async Task Setup() 
    {
        var playwright = await Playwright.CreateAsync();
        var browserTypeProperty = playwright.GetType().GetProperty(Config.BrowserName, 
            System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.IgnoreCase);
        var browserType = browserTypeProperty.GetValue(playwright) as IBrowserType;
        var browser = await browserType.LaunchAsync(new BrowserTypeLaunchOptions { Headless = Config.Headless });
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
        var screenshotPath = Path.Combine(Config.ScreenshotFolder, $"{_scenarioContext.ScenarioInfo.Title}_screenshot.png");
        var screenshot = await Page.ScreenshotAsync(new()
            {
                Path = screenshotPath,
                FullPage = true
            });
        test.Log(Status.Fail,"TEST CASE FAILED AT THIS TEST STEP") ;   
        test.Log(Status.Info, "Screenshot of failure Step :", MediaEntityBuilder.CreateScreenCaptureFromPath(screenshotPath).Build());
        //test.Fail("Screenshot on failure:").AddScreenCaptureFromPath(screenshotPath);
    }
}
