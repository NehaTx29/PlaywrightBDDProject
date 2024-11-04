// using AventStack.ExtentReports;
// using AventStack.ExtentReports.Reporter;
// using Microsoft.Playwright;
// using Microsoft.Playwright.NUnit;
// using TechTalk.SpecFlow.Events;

// namespace PlaywrightTests;

// public class Tests : PageTest
// {
//     private new IBrowser Browser;
//     private new IPage Page;
//     private static ExtentReports extent;
//     private static ExtentTest test;
    
//     [OneTimeSetUp]
//     public static void SetupReport()
//     {
//         var htmlReporter = new ExtentSparkReporter("ExtentReports.html");
//         extent = new ExtentReports();
//         extent.AttachReporter(htmlReporter);
//     }

//     [SetUp]
//     public async Task Setup() 
//     {
//             Browser = await Playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions{ Headless = false });
//             Page = await Browser.NewPageAsync();
//             test = extent.CreateTest(TestContext.CurrentContext.Test.Name);
//     }

//     [Test]
//     public async Task HasTitle()
//     {
//         await Page.GotoAsync("https://www.google.com");
//         await Expect(Page).ToHaveTitleAsync("Google");
//         test.Log(Status.Pass, "Title is correct.");
//     }

//     [Test]
//     public async Task HasTypeText()
//     {
//         await Page.GotoAsync("https://www.google.com");
//         await Page.Locator("[title = Search]").FillAsync("Neha Test");
//         await Page.Locator("[title = Search]").PressAsync("Enter");
//         test.Pass("Input is correct.");
//     }

//     [TearDown]
//     public async Task TearDown() 
//     {
//         await Browser.CloseAsync();
//     }

//     [OneTimeTearDown]
//     public static void TearDownReport()
//     {
//         extent.Flush();
//     }
// }
