// using Microsoft.Playwright;
// using Microsoft.Playwright.NUnit;
// using TechTalk.SpecFlow;
// using TechTalk.SpecFlow.Events;
// using AventStack.ExtentReports;
// using AventStack.ExtentReports.Reporter;

// [Binding]
// public class SampleBingSearch
// {
//     private IPage _page;
//     private static ExtentReports extent;
//     private ExtentTest test;
//     private ScenarioContext _scenarioContext;

//     public SampleBingSearch(ScenarioContext scenarioContext)
//     {
//         _scenarioContext = scenarioContext;
//     }

//     [BeforeTestRun]
//     public static void SetupReport()
//     {
//         var htmlReporter = new ExtentSparkReporter("ExtentReports.html");
//         extent = new ExtentReports();
//         extent.AttachReporter(htmlReporter);
//     }

//     [BeforeScenario]
//     public async Task Setup() 
//     {
//         var playwright = await Playwright.CreateAsync();
//         var browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions { Headless = false });
//         _page = await browser.NewPageAsync();
//         test = extent.CreateTest(_scenarioContext.ScenarioInfo.Title);
//     }

//     [Given(@"I perform Bing Search")]
//     public async Task IperformBingSearch()
//     {
//         await _page.GotoAsync("https://www.bing.com");
//         test.Pass("Navigated to website");
//     }

//     [AfterScenario]
//     public async Task TearDown()
//     {
//         // Clean up after each scenario
//         await _page.CloseAsync();

//         // Flush report to ensure it's updated after each scenario
//         extent.Flush();
//     }

//     [AfterTestRun]
//     public static void TearDownReport()
//     {
//         // Finalize the Extent report after all tests are complete
//         extent.Flush();
//     }
// }
