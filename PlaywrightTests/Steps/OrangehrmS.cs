using NUnit.Framework;
using Microsoft.Playwright;
using TechTalk.SpecFlow;
using AventStack.ExtentReports;
using System.Threading.Tasks;


    [Binding]
    public class OrangehrmS : BasePage
    {
        [Given(@"I am on the login page")]
        public async Task GivenIAmOnTheLoginPage()
        {
            // Navigate to login page
            await Page.GotoAsync("https://opensource-demo.orangehrmlive.com/web/index.php/auth/login");
            TestHooks.test.Log(Status.Pass, "Navigated to the login page.");
        }

       [When(@"I enter ""(.*)"" , ""(.*)"" and login")]
    public async Task WhenIEnterAValidUsernameAndPasswordAndLogin(string loginUsername, string loginPassword)
        {
            // Enter the username and password to log in
            await Page.FillAsync("//input[@placeholder='Username']", loginUsername);
            await Page.FillAsync("//input[@placeholder='Password']", loginPassword);
            await Page.ClickAsync("//button[normalize-space()='Login']");
            TestHooks.test.Log(Status.Pass, "Entered valid credentials and logged in.");
        }

        [When(@"I click on Apply Leave")]
        public async Task WhenIClickOnApplyLeave()
        {
            // Click on the Apply Leave button
            await Page.ClickAsync("//button[@title='Apply Leave']//*[name()='svg']");
            TestHooks.test.Log(Status.Pass, "Clicked on Apply Leave.");
        }

        [Then(@"I enter the details in the form and Apply")]
        public async Task WhenIEnterTheDetailsInTheFormAndApply()
        {
            // Fill out the leave application form
            await Page.ClickAsync("//div[@class='oxd-select-text-input']");

            await Page.ClickAsync("//div[@role='listbox']//div[2]");
           
            await Page.FillAsync("//div[@class='oxd-grid-4 orangehrm-full-width-grid']//div[1]//div[1]//div[2]//div[1]//div[1]//input[1]","09-12-2024");
            await Page.FillAsync("//div[@class='oxd-grid-4 orangehrm-full-width-grid']//div[1]//div[1]//div[2]//div[1]//div[1]//input[1]","12-12-2024");
            await Page.ClickAsync("//button[normalize-space()='Apply']");
            TestHooks.test.Log(Status.Pass, "Entered leave details and applied.");
        }
    }

