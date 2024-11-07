using Microsoft.Playwright;
using TechTalk.SpecFlow;
using NUnit.Framework;
using System.Threading.Tasks;

namespace EcommerceTests
{
    [Binding]
    public class EcommerceLoginSteps : BasePage
    {
        private IPage _page;
        
        [Given(@"I am on the login page")]
        public async Task GivenIAmOnTheLoginPage()
        {
            // Navigate to the login page
            await _page.GotoAsync("https://www.ajio.com/?&utm_source=google&utm_medium=cpc&utm_campaign=GSB_Brand_August2019&gad_source=1&gclid=CjwKCAiAxKy5BhBbEiwAYiW--4jMIG4pjHNJ2bPwGSV-S46QB0UDlC6y-_D59-paV2WJmxz6hZVvkxoCdVEQAvD_BwE");
        }

        [When(@"I enter a valid mobile number ""(.*)"" and enter the OTP ""(.*)""")]
        public async Task WhenIEnterAValidMobileNumberAndEnterTheOTP(string mobileNumber, string otp)
        {
            // Locate the mobile number input field and enter the value
            var mobileInput = await _page.Locator("input[name='mobile']");
            await mobileInput.FillAsync(mobileNumber);

            // Locate the OTP input field and enter the OTP
            var otpInput = await _page.Locator("input[name='otp']");
            await otpInput.FillAsync(otp);
        }

        [When(@"I click the ""Start Shopping"" button")]
        public async Task WhenIClickTheStartShoppingButton()
        {
            // Locate the Start Shopping button and click it
            var startShoppingButton = await _page.Locator("button#start-shopping");
            await startShoppingButton.ClickAsync();
        }

        [Then(@"I should be redirected to the homepage")]
        public async Task ThenIShouldBeRedirectedToTheHomepage()
        {
            // Check that the user is redirected to the homepage (e.g., verify the URL)
            var url = _page.Url;
            Assert.IsTrue(url.Contains("/home"), "User was not redirected to the homepage.");

            // Alternatively, check if a specific element on the homepage is visible
            var homepageElement = await _page.Locator("div.home-banner");
            Assert.IsTrue(await homepageElement.IsVisibleAsync(), "Homepage banner is not visible.");
        }
    }
}
